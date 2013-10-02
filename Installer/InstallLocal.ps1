#Requires -Version 3.0
$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

function Main
{
	Write-Host "Install PSCodeAnalyzer.ISEAddin to PSModule path"
    $ModuleName = "PSCodeAnalyzer.ISEAddin"
	$path = Join-Path $PSScriptRoot "Modules\PSCodeAnalyzer.ISEAddin"
    Install-PSModule -ModuleName $ModuleName -Path $path
}

function Install-PSModule
{
    [CmdletBinding()]
    param (
        [Parameter(Mandatory)]
        [string] $ModuleName,
        [Parameter(Mandatory)]
        [string] $Path,
        [ValidateSet("User", "System", "ProgramFiles", "Local")]
        [string] $Target = "User"
    )
    $ErrorActionPreference = "Stop"
    Set-StrictMode -Version Latest

    if (!(Test-Path $Path -PathType Container)){
        Write-Error ("Directory is not found! : {0}" -f $Path)
    }

    #Resolve target module base directory
    switch ($Target)
    {
        "Local"{
            $moduleBasePath = Join-Path (Resolve-Path .) "Modules" #Use Current Directory
        }
        default{ 
            $moduleBasePath = $env:PSModulePath.Split(";") | where { $_ -like ("{0}*" -f [Environment]::GetFolderPath($Target))} | select -First 1
        }
    }

	#Validate module directory exist
    if ([String]::IsNullOrEmpty($moduleBasePath)){
        throw ("PowerShell module path is not found for target({0})" -f $Target)
    }
   
    #Set target module directory
    $modulePath = Join-Path $moduleBasePath $ModuleName
 
    #Change current directory to get relative path from module root
    Push-Location -Path $Path
    try {
		#Get files under current directory
        $items = Get-ChildItem -File -Recurse 
        Write-Verbose ("Install PowerShell module to '{0}'..." -f $modulePath)
        foreach ($item in $items)
        {
            #Relative path to CopyFrom basepath
            $relativePath = Resolve-Path $item.FullName -Relative

            #Copy file operation target path 
            $destination = Join-Path $modulePath $relativePath

            #Create directory if not exist already
            (New-Object IO.FileInfo($destination)).Directory.Create()
            
            Write-Verbose ("`tCopy file '{0}'" -f $relativePath)
            Copy-Item -Path $item.FullName -Destination $destination -Force
        }
    }
    finally
    {
        Pop-Location -ErrorAction Ignore
    }
}

#execute Main function with dot-sourced
. Main