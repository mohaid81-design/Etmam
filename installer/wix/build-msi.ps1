<#
Builds installer\Output\EtmamSetup.msi. The version is not duplicated here - it's parsed
straight out of ..\EtmamSetup.iss's `#define MyAppVersion "X.X.X"` line, the single place
that number is set today, so the Inno EXE and this MSI can never drift apart. Bump the
version there; this script (and the MSI it produces) picks it up automatically.
#>
$ErrorActionPreference = "Stop"

$scriptDir = $PSScriptRoot
$issPath = Join-Path $scriptDir "..\EtmamSetup.iss"
$wxsPath = Join-Path $scriptDir "Etmam.wxs"
$outPath = Join-Path $scriptDir "..\Output\EtmamSetup.msi"

$issContent = Get-Content $issPath -Raw
$match = [regex]::Match($issContent, '#define\s+MyAppVersion\s+"([^"]+)"')
if (-not $match.Success) {
    throw "Could not find #define MyAppVersion `"...`" in $issPath"
}
$version = $match.Groups[1].Value
Write-Output "Building EtmamSetup.msi version $version (from EtmamSetup.iss)"

# Source file paths in Etmam.wxs are relative to the .wxs file itself, so build from there.
Push-Location $scriptDir
try {
    wix build "Etmam.wxs" -arch x64 -ext WixToolset.UI.wixext -ext WixToolset.Util.wixext -d "ProductVersion=$version" -out $outPath
    if ($LASTEXITCODE -ne 0) {
        throw "wix build failed with exit code $LASTEXITCODE"
    }
}
finally {
    Pop-Location
}

Write-Output "Built: $outPath"
