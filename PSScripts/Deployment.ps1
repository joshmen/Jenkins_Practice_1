Param
(
	[Parameter(Mandatory=$true)]
	[string]$ServerName,
	[Parameter(Mandatory=$true)]
	$InstallationPathOnServer,
	[Parameter(Mandatory=$true)]
	$LogFile,
	[Parameter(Mandatory=$true)]
	$EnvironmentSettingsFileName,
	[Parameter(Mandatory=$true)]
	$ThisIsTheLastServer
)

Function DeployMSI($ServerName,$InstallationPathOnServer,$LogFile,$EnvironmentSettingsFileName,$ThisIsTheLastServer)
{

	Write-Host("ServerName: " + $ServerName)
	Write-Host("InstallationPathOnServer: " + $InstallationPathOnServer)
	Write-Host("LogFile: " + $LogFile)
	Write-Host("EnvironmentSettingsFileName: " + $EnvironmentSettingsFileName)
	Write-Host("ThisIsTheLastServer: " + $ThisIsTheLastServer)
	if(($ServerName -eq $null) -or ($InstallationPathOnServer -eq $null) -or ($LogFile -eq $null) -or ($EnvironmentSettingsFileName -eq $null) -or ($ThisIsTheLastServer -eq $null))
	{
		Write-Host("One or more parameters for this PS are missing")
	}
	else
	{
	
		$Username = '[username]'
		$Password = '[password]'
		$pass = ConvertTo-SecureString -AsPlainText $Password -Force
		$Cred = New-Object System.Management.Automation.PSCredential -ArgumentList $Username,$pass

		$DeploymentProjectPath=$InstallationPathOnServer + "\Deployment\Deployment.btdfproj"
		$ExportedSettingsPath=$InstallationPathOnServer + "\Deployment\EnvironmentSettings\" + $EnvironmentSettingsFileName
		
		[string]$DeploymentProjectPathArgument= " `"" + $DeploymentProjectPath + "`""
		[string]$LogFileArgument =  " /l:FileLogger,Microsoft.Build.Engine;logfile=`"" + $LogFile + "`""
		[string]$EnvironmentSettingsArgument = " /p:ENV_SETTINGS=`"" + $ExportedSettingsPath + "`""
		[string]$DeploymentSettingsArgument = "/p:DeployBizTalkMgmtDB=" + $ThisIsTheLastServer + ";Configuration=Server;SkipUndeploy=false"
		
		Invoke-Command -Computername $ServerName -authentication Credssp -credential $Cred -Verbose -ScriptBlock {
			$DeployArguments = @(
				$args[0]
				$args[1]
				"/target:Deploy"
				$args[2]
				$args[3]
			)
			Start-Process "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" -ArgumentList $DeployArguments -Wait -ErrorAction Stop
		} -ArgumentList $DeploymentProjectPathArgument,$DeploymentSettingsArgument,$LogFileArgument,$EnvironmentSettingsArgument
	}
}

DeployMSI -ServerName $ServerName -InstallationPathOnServer $InstallationPathOnServer -LogFile $LogFile -EnvironmentSettingsFileName $EnvironmentSettingsFileName -ThisIsTheLastServer $ThisIsTheLastServer