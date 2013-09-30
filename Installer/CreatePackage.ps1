#Requires -Version 3.0
param(
[Parameter(Mandatory)]
[string] $Name
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

#Zip archive file name
$fileName = "PSCodeAnalyzer.zip"

#Create zip file to current directory
Write-Verbose ("Create zip archive file...")
Add-Type -AssemblyName System.IO.Compression.FileSystem
$compressionLevel = [IO.Compression.CompressionLevel]::Optimal
$includeBaseDir = $false
$filePath = Join-Path (Get-Location) $fileName
$zipTargetPath = (Resolve-Path "Modules\PSCodeAnalyzer.ISEAddin").ProviderPath

if(Test-Path $filePath){
	Remove-Item $filePath -Force
}
[IO.Compression.ZipFile]::CreateFromDirectory($zipTargetPath,$filePath, $compressionLevel, $includeBaseDir)

#Copy to archive directory
Write-Verbose ("Copy zip file to archive directory")
$archiveDir = Join-Path "Archives" $Name
$destination = Join-Path $archiveDir $fileName
(New-Object IO.FileInfo($destination)).Directory.Create()
Copy-Item -Path $filePath -Destination $destination -Force
