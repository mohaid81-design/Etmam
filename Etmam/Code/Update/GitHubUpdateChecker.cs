using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Etmam.Code.Update
{
    /// <summary>Queries the public GitHub Releases API for this app's own repo to find the
    /// latest published version - replaces manually setting Data.UpdateSettings' DB-shared
    /// LatestAppVersion by hand on every release. See Gui/MainPage/frmStart.cs for where this
    /// gates login and Gui/MainPage/frmUpdateRequired.cs for the "Update Now" button that
    /// downloads InstallerDownloadUrl.</summary>
    public static class GitHubUpdateChecker
    {
        private const string Owner = "mohaid81-design";
        private const string Repo = "Etmam";

        private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(10) };

        public sealed record LatestRelease(string Version, string? InstallerDownloadUrl);

        /// <summary>Returns null on any failure (offline, GitHub unreachable, no releases yet,
        /// unexpected response shape) rather than throwing - callers must treat null the same as
        /// "couldn't determine, don't block login", matching the fail-open philosophy the old
        /// DB-based gate already used for an unconfigured setting.</summary>
        public static async Task<LatestRelease?> GetLatestReleaseAsync()
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get,
                    $"https://api.github.com/repos/{Owner}/{Repo}/releases/latest");
                request.Headers.UserAgent.Add(new ProductInfoHeaderValue("Etmam-App", null));
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));

                using var response = await Http.SendAsync(request).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode) return null;

                await using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                using var doc = await JsonDocument.ParseAsync(stream).ConfigureAwait(false);
                var root = doc.RootElement;

                if (!root.TryGetProperty("tag_name", out var tagProp)) return null;
                var tag = tagProp.GetString();
                if (string.IsNullOrWhiteSpace(tag)) return null;

                // Releases are tagged "v1.3.1" by convention - strip the leading v/V so the rest
                // parses as a plain System.Version, same as frmStart's VersionCore does for
                // Application.ProductVersion.
                var version = tag.TrimStart('v', 'V');

                string? installerUrl = null;
                if (root.TryGetProperty("assets", out var assets))
                {
                    foreach (var asset in assets.EnumerateArray())
                    {
                        var name = asset.TryGetProperty("name", out var nameProp) ? nameProp.GetString() : null;
                        if (name != null && name.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                        {
                            installerUrl = asset.TryGetProperty("browser_download_url", out var urlProp)
                                ? urlProp.GetString()
                                : null;
                            break;
                        }
                    }
                }

                return new LatestRelease(version, installerUrl);
            }
            catch
            {
                return null;
            }
        }
    }
}
