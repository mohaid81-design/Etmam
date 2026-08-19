using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using Etmam.Properties;

namespace Etmam
{
    /// <summary>
    /// Launches the Api project as a local child process at startup when nothing is already
    /// listening on ApiBaseUrl, so users never have to start it by hand. Manages the lifetime of
    /// a process it started itself across sessions too (via a PID file, see KillOrphanedInstance) -
    /// a genuinely external instance (dev workflow with a separately-launched API, or a shared
    /// instance someone else started, neither of which ever wrote that PID file) is left alone.
    /// </summary>
    public static class ApiProcessManager
    {
        private static Process? _startedProcess;

        public static void EnsureStarted()
        {
            if (_startedProcess is { HasExited: false }) return;

            var (host, _) = ParseHostPort(Settings.Default.ApiBaseUrl);
            if (host is not ("localhost" or "127.0.0.1")) return; // remote API: nothing to launch locally

            // Something is already answering on this port - reuse it instead of racing to bind
            // the same port ourselves. Without this check, EnsureStarted always killed whatever
            // the PID file pointed to and launched a fresh Api.exe unconditionally, so two Etmam
            // sessions started close together (or a second launch before the first's Api.exe had
            // fully released the port) would collide on "address already in use". _startedProcess
            // stays null here deliberately: this instance isn't ours to Shutdown() later.
            if (IsApiListeningAsync().GetAwaiter().GetResult()) return;

            // Anything left behind by a PREVIOUS run of this same app (crash, force-close, unclean
            // shutdown that skipped Shutdown() below) would otherwise keep answering requests
            // forever with whatever connection string it was originally started with - silently
            // ignoring any connection-profile change made since (frmConnecting) even after a full
            // Application.Restart(), because that stale process was never this session's
            // _startedProcess and so Shutdown() has no way to find it. Concretely: this was the
            // root cause of a real "only the admin account can log in over the LAN" report - the
            // orphaned instance was still serving a stale/local database that only had an admin
            // row, while every real user only existed in the properly-configured network database.
            KillOrphanedInstance();

            var startInfo = FindLaunchTarget();
            if (startInfo == null) return;

            // Hand the Api process the same active connection profile Etmam itself already
            // resolved (Data.DBSetting - the DPAPI-encrypted per-user store frmConnecting edits),
            // via ASP.NET Core's standard env-var config convention (double underscore = ":").
            // Can't just have Api reference Data and call DBSetting directly: .NET user-scoped
            // settings resolve their user.config path from the *entry assembly's* identity, so
            // Api.exe would land on a completely different (empty) file than Etmam.exe wrote to.
            var connectionString = Data.DBSetting.GetConString();
            if (!string.IsNullOrWhiteSpace(connectionString))
                startInfo.Environment["ConnectionStrings__DefaultConnection"] = connectionString;

            // Same reasoning as the connection string above: a fixed key persisted via
            // Data.ApiJwtKeySetting (DPAPI-protected, per Windows user) rather than the empty
            // placeholder in Api/appsettings.json, so tokens survive an Api restart.
            startInfo.Environment["Jwt__Key"] = Data.ApiJwtKeySetting.GetOrCreateKey();

            // Capture Api.exe's own console output to a log file - without this, a startup crash
            // (e.g. an unhandled exception in Program.cs, a port already in use, a bad connection
            // string) is completely invisible: IsApiListeningAsync just keeps returning false
            // forever with nothing in the UI or anywhere else explaining why. This was the actual
            // cause of a real "stuck on 'starting system server'" report on a freshly-installed
            // machine (Kestrel failing to bind its HTTPS listener because no dev certificate had
            // ever been generated there - see api-startup.log after the switch to HTTP-only below).
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;

            try
            {
                _startedProcess = Process.Start(startInfo);
                if (_startedProcess != null)
                {
                    var logPath = GetStartupLogPath();
                    Directory.CreateDirectory(Path.GetDirectoryName(logPath)!);
                    File.AppendAllText(logPath, $"--- {DateTime.Now:O} Api.exe starting ---\n");

                    _startedProcess.OutputDataReceived += (_, e) => AppendLog(logPath, e.Data);
                    _startedProcess.ErrorDataReceived += (_, e) => AppendLog(logPath, e.Data);
                    _startedProcess.BeginOutputReadLine();
                    _startedProcess.BeginErrorReadLine();

                    // Recorded so a FUTURE run of this app (after a crash/force-close that skips
                    // Shutdown() below) can find and clean up this exact process via
                    // KillOrphanedInstance, instead of leaving it running forever in the background.
                    try { File.WriteAllText(GetPidFilePath(), _startedProcess.Id.ToString()); } catch { /* best effort */ }
                }
            }
            catch
            {
                _startedProcess = null;
            }
        }

        public static string GetStartupLogPath() => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Etmam", "api-startup.log");

        private static string GetPidFilePath() => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Etmam", "api.pid");

        /// <summary>Kills whatever process a PREVIOUS session of this app recorded as its own
        /// locally-spawned Api instance, if it's still running - see EnsureStarted's comment for
        /// why a leftover instance is dangerous (silently serving a stale connection string).
        /// Matches on process name too before killing, in case the OS has since reused that PID
        /// for an unrelated process (only ever a concern long after the original exited).</summary>
        private static void KillOrphanedInstance()
        {
            var pidFile = GetPidFilePath();
            try
            {
                if (!File.Exists(pidFile)) return;
                if (!int.TryParse(File.ReadAllText(pidFile).Trim(), out var pid)) return;

                var process = Process.GetProcessById(pid);
                if (process.ProcessName is "Api" or "dotnet")
                    process.Kill(entireProcessTree: true);
            }
            catch
            {
                // Process.GetProcessById throws ArgumentException when the PID no longer exists -
                // the common, expected case after a clean shutdown already deleted the file, or
                // Windows reused the PID for something else entirely (name check above guards that).
            }
            finally
            {
                try { File.Delete(pidFile); } catch { /* best effort */ }
            }
        }

        private static void AppendLog(string logPath, string? line)
        {
            if (line == null) return;
            try { File.AppendAllText(logPath, $"{DateTime.Now:O} {line}\n"); } catch { /* best effort */ }
        }

        public static async Task<bool> IsApiListeningAsync(int timeoutMs = 500)
        {
            var (host, port) = ParseHostPort(Settings.Default.ApiBaseUrl);
            if (host is null || port is null) return false;

            try
            {
                using var client = new TcpClient();
                var connectTask = client.ConnectAsync(host, port.Value);
                var completed = await Task.WhenAny(connectTask, Task.Delay(timeoutMs)).ConfigureAwait(false);
                return completed == connectTask && client.Connected;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Stops the API process this instance started. Safe to call multiple times
        /// (e.g. from both Application.ApplicationExit and AppDomain.ProcessExit).</summary>
        public static void Shutdown()
        {
            if (_startedProcess is { HasExited: false } process)
            {
                try { process.Kill(entireProcessTree: true); } catch { /* best effort */ }
            }

            // Clean exit path: no orphan left behind, so nothing for the next session's
            // KillOrphanedInstance to find - stale PID file would otherwise point at a since-recycled
            // PID that may belong to an unrelated process by the time this app next launches.
            try { File.Delete(GetPidFilePath()); } catch { /* best effort */ }
        }

        private static (string? host, int? port) ParseHostPort(string baseUrl)
        {
            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var uri)) return (null, null);
            return (uri.Host, uri.Port);
        }

        // Published/installed layout: an "Api" folder sits next to Etmam.exe.
        // Dev/source layout: an "Api\Api.csproj" sibling of the checked-out "Etmam" folder,
        // found by walking up from the build output directory.
        private static ProcessStartInfo? FindLaunchTarget()
        {
            var exeDir = AppContext.BaseDirectory;

            var installedApiExe = Path.Combine(exeDir, "Api", "Api.exe");
            if (File.Exists(installedApiExe))
            {
                return new ProcessStartInfo(installedApiExe)
                {
                    WorkingDirectory = Path.GetDirectoryName(installedApiExe)!,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                };
            }

            var apiProject = FindSourceApiProject(exeDir);
            if (apiProject != null)
            {
                var startInfo = new ProcessStartInfo("dotnet")
                {
                    WorkingDirectory = Path.GetDirectoryName(apiProject)!,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                };
                startInfo.ArgumentList.Add("run");
                startInfo.ArgumentList.Add("--project");
                startInfo.ArgumentList.Add(apiProject);
                startInfo.ArgumentList.Add("--launch-profile");
                startInfo.ArgumentList.Add("http");
                return startInfo;
            }

            return null;
        }

        private static string? FindSourceApiProject(string startDir)
        {
            var dir = new DirectoryInfo(startDir);
            for (var i = 0; i < 8 && dir is not null; i++, dir = dir.Parent)
            {
                var candidate = Path.Combine(dir.FullName, "Api", "Api.csproj");
                if (File.Exists(candidate)) return candidate;
            }
            return null;
        }
    }
}
