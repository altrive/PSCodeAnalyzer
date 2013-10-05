#Requires -Version 3.0
$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

function Main
{
    if($PSVersionTable.PSVersion.Major -lt 3){
        Write-Error "PowerShell 3.0 or above required!"
    }

    $ModuleName = "PSCodeAnalyzer.ISEAddin"
    $Url = "https://github.com/altrive/PSCodeAnalyzer/raw/master/Installer/PSCodeAnalyzer.zip"
    try
    {
        $extractedPath = Get-ZipContentFromUrl -Url $Url -Verbose
        Install-PSModule -ModuleName $ModuleName -Path $extractedPath -Verbose
        Add-StartupModuleLoading -ModuleName $ModuleName -Verbose
    }
    finally {
        Remove-Item -path $extractedPath -Force -ErrorAction Ignore -Recurse
    }
}

function Add-StartupModuleLoading
{
    [CmdletBinding()]
    param (
		[Parameter(Mandatory)]
        [string] $ModuleName
    )

    if ($Host.Name -ne "Windows PowerShell ISE Host"){
        Write-Verbose "Current host is not PowerShell ISE..."
        return
    }

    $statement = "Import-Module {0}" -f $ModuleName

    $lines = Get-Content -Path $profile -ErrorAction Ignore
    if (($lines -ne $null) -and ($lines.Contains($statement))){
        Write-Verbose "PSModule auto load settings already exist in profile."
        return
    }

    $choices = [Management.Automation.Host.ChoiceDescription[]]("&Yes","&NO")
    if($Host.UI.PromptForChoice("Confirm", "Do you want to enable auto module loading when ISE started?`r`n(if you select 'yes' following statement is appended to current profile).`r`n`r`n$statement", $choices, 1) -eq 0){
        Write-Verbose ("Add PSModule import statement to current powershell profile file: {0}" -f $profile)
        Add-Content -Path $profile -Value ""
		Add-Content -Path $profile -Value $statement
    }
}

function Get-ZipContentFromUrl
{
    [OutputType([string])]
    [CmdletBinding()]
    param (
		[Parameter(Mandatory)]
        [string] $Url
    )

    $tempDir = Join-Path ([IO.Path]::GetTempPath()) ([Guid]::NewGuid())
    $tempFilePath = Join-Path $tempDir "temp.zip"
    (New-Object IO.FileInfo($tempFilePath)).Directory.Create()
    try {
        #Download zip file
        Write-Verbose ("Download file '{0}'" -f $Url)
        Invoke-WebRequest -Uri $Url -OutFile $tempFilePath -Verbose:$false

        #Unblock zip file
        Unblock-File -Path $tempFilePath
   
        #Extract zip file
        Write-Verbose ("Extract zip content...")
        Add-Type -AssemblyName System.IO.Compression.FileSystem
        [IO.Compression.ZipFile]::ExtractToDirectory($tempFilePath, $tempDir)
    }
    finally {
        #Remove zip file
        Write-Verbose ("Remove zip file...")
        Remove-Item -Path $tempFilePath -Force -ErrorAction Ignore
    }

    #Return extracted content directory
    return $tempDir
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
			#TODO:Specify ProgramFiles may exists multiple items
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
