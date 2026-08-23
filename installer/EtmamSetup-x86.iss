#define MyAppName "Etmam"
#define MyAppNameArabic "نظام إتمام لإدارة المشاريع"
#define MyAppVersion "1.3.0"
#define MyAppPublisher "Etmam"
#define MyAppExeName "Etmam.exe"
#define MyPublishDir "..\publish-release-x86"

[Setup]
; Same AppId as the x64 installer (EtmamSetup.iss) - both are the same product, just built
; for a different architecture, so an existing install (either flavor) upgrades in place.
AppId={{6E9B2C9B-6E2C-4A7A-9E0E-2D9C8C9A4E11}
AppName={#MyAppName} - {#MyAppNameArabic}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
OutputDir=Output
OutputBaseFilename=EtmamSetup-x86
SetupIconFile=..\Etmam\Resources\etmam.ico
Compression=lzma2/ultra64
SolidCompression=yes
; No ArchitecturesAllowed/ArchitecturesInstallIn64BitMode restriction here (unlike the x64
; .iss) - the payload is a win-x86 self-contained build, so it runs unmodified on both
; 32-bit and 64-bit Windows. {autopf} then resolves to Program Files (x86) on 64-bit
; machines and Program Files on 32-bit ones, matching the bitness of what's installed.
WizardStyle=modern
UninstallDisplayIcon={app}\{#MyAppExeName}

[Languages]
Name: "arabic"; MessagesFile: "compiler:Languages\Arabic.isl"
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
; Ship the self-contained build as a plain folder (NOT single-file) - includes the .NET runtime,
; no separate .NET install needed on the target machine. .pdb debug symbols are intentionally
; excluded from the end-user package.
;
; NOT single-file: see EtmamSetup.iss's matching comment - publishing Etmam.exe with
; PublishSingleFile=true makes every DB connection attempt fail with a swallowed
; DllNotFoundException (Microsoft.Data.SqlClient's native SNI loader can't resolve its own DLL's
; location when Assembly.Location is empty, which is exactly what happens in a single-file bundle).
Source: "{#MyPublishDir}\*"; DestDir: "{app}"; Excludes: "\Api\*,*.pdb"; Flags: ignoreversion recursesubdirs createallsubdirs
; The Api project, self-contained folder-published the same way (also NOT single-file - see
; EtmamSetup.iss's matching comment), in a sibling "Api" folder - Etmam.exe launches it
; automatically on startup (see Etmam/Code/Api/ApiProcessManager.cs) by looking for
; "<install dir>\Api\Api.exe". Excludes are publish-output noise that isn't needed at runtime:
; .pdb symbols, the IIS-only web.config, and the dev-only appsettings file (appsettings.json -
; the one that IS shipped - still needs its ConnectionStrings:DefaultConnection and Jwt:Key
; filled in with real production values before this installer is distributed; see
; docs/api-migration-checklist.md).
Source: "{#MyPublishDir}\Api\*"; DestDir: "{app}\Api"; Excludes: "*.pdb,\BuildHost-net472\*,\BuildHost-netcore\*,\web.config,\appsettings.Development.json"; Flags: ignoreversion recursesubdirs createallsubdirs
; Properly install Cairo (a variable font) as a real Windows system font. The app also
; registers it in-process via AddFontMemResourceEx as a fallback (e.g. for `dotnet run`
; without the installer), but that classic-GDI in-memory path only exposes the font's
; default instance with incomplete metrics on some Windows builds - causing correct glyphs
; but wrong sizing/spacing/overlap. A real OS-level install goes through the full modern
; (DirectWrite-aware) font stack and gets correct metrics everywhere, matching how it
; already renders on machines where Cairo happens to be installed system-wide.
Source: "..\Etmam\Resources\Fonts\Cairo-VariableFont.ttf"; DestDir: "{autofonts}"; FontInstall: "Cairo"; Flags: onlyifdoesntexist uninsneveruninstall

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#MyAppName}}"; Flags: nowait postinstall skipifsilent

[Code]
// Detects a previously installed copy of this app (same AppId, any install path/version)
// via its uninstall registry entry, and runs its uninstaller silently before this
// version's files are copied in - so no old-version leftovers remain on the machine.
function GetUninstallString(): String;
var
  sUnInstPath: String;
  sUnInstallString: String;
begin
  sUnInstPath := 'Software\Microsoft\Windows\CurrentVersion\Uninstall\{6E9B2C9B-6E2C-4A7A-9E0E-2D9C8C9A4E11}_is1';
  sUnInstallString := '';
  if not RegQueryStringValue(HKLM, sUnInstPath, 'UninstallString', sUnInstallString) then
    RegQueryStringValue(HKCU, sUnInstPath, 'UninstallString', sUnInstallString);
  Result := sUnInstallString;
end;

function IsUpgrade(): Boolean;
begin
  Result := (GetUninstallString() <> '');
end;

procedure UninstallOldVersion();
var
  sUnInstallString: String;
  iResultCode: Integer;
begin
  sUnInstallString := GetUninstallString();
  if sUnInstallString <> '' then
  begin
    sUnInstallString := RemoveQuotes(sUnInstallString);
    Exec(sUnInstallString, '/VERYSILENT /SUPPRESSMSGBOXES /NORESTART', '', SW_HIDE, ewWaitUntilTerminated, iResultCode);
  end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if (CurStep = ssInstall) and IsUpgrade() then
    UninstallOldVersion();
end;
