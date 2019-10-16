Param
(
	[Parameter(Mandatory=$true)]
	$MsiPath,
	[Parameter(Mandatory=$true)]
	$InstallPath,
	[Parameter(Mandatory=$true)]
	$LogFile
)
Function InstallBTDFMSI ($MsiPath, $InstallPath, $LogFile)
{
	Write-Host("MSIPath: " + $MsiPath)
	Write-Host("InstallPath: " + $InstallPath)
	Write-Host("LogFile: " + $LogFile)
	if(($MsiPath -eq $null) -or ($InstallPath -eq $null) -or ($LogFile -eq $null))
	{
		Write-Host("MSI Path /Install Path /LogFile is missing")
	}
	else
	{
		cls
		Write-Host("Installation of MSI started")
		[string]$InstallArgument= "/i `"" + $MsiPath + "`""
		[string]$InstalDirArgument =  "TARGETDIR=`"" + $InstallPath + "`""
		[string]$LogDirArgument =  "/log `"" + $LogFile + "`""
		$MSIArguments = @(
			$InstallArgument
			"/qn"
			"/norestart"
			$LogDirArgument 
			$InstalDirArgument
		)
		Write-Host ($MSIArguments)
		try
		{
			Start-Process "msiexec.exe" -ArgumentList $MSIArguments -Wait -ErrorAction Stop
		}
		catch
		{
			write-host $error[0]
			throw $LASTEXITCODE
		}
		ExportEnvironmentSettingsFile -InstallPath $InstallPath
	}
}
Function ExportEnvironmentSettingsFile ($InstallPath)
{
	Write-Host("Exporting environment settings...")
	$SettingsFilePath = $InstallPath + "\Deployment\EnvironmentSettings\SettingsFileGenerator.xml"
	$SettingsFileExtractPath = $InstallPath + "\Deployment\EnvironmentSettings"
	$FilePath = "`"" + $InstallPath + "\Deployment\Framework\DeployTools\EnvironmentSettingsExporter.exe" + "`""
	$ArgumentList = "`"" + $SettingsFilePath + "`" `"" + $SettingsFileExtractPath + "`""
	try
	{
		Start-Process -FilePath $FilePath -ArgumentList $ArgumentList -Wait -ErrorAction Stop
	}
	catch
	{
		write-host $error[0]
		throw $LASTEXITCODE
	}
}
InstallBTDFMSI -MsiPath $MsiPath -InstallPath $InstallPath -LogFile $LogFile