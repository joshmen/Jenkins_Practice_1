Param
(
	[Parameter(Mandatory=$true)]
	[string]$BTDFProjFilePath
)

Function UpdateBTDFFile($BTDFProjFilePath)
{
	if(Test-Path $BTDFProjFilePath)
	{
		Write-Host("Found the valid path for the btdf Project File")
		Write-Host("This script will now try to change the Product version and Product GUID")
		$btdfprojxml= new-object xml
		[xml]$btdfprojxml = get-content -path $BTDFProjFilePath
		$Guid = [guid]::NewGuid()
		foreach($projectgroup in $btdfprojxml.Project.PropertyGroup)
		{
			if( $projectgroup.ProductVersion -ne $null)
			{
				[string]$productId = $projectgroup.ProductVersion
				$len=$productId.length
				$version = $productId.Substring(4,$len-4)
				[int]$versionint= $version
				Write-Host("Current Version of the product is $productId")
				Write-Host("Attempting to increment the product version now")
				$versionint = $versionint +1
				$versionNew = $versionint
				if($versionint -le 9)
				{
					$versionNew = "0$versionint"
				}
				$productId = $productId.Substring(0,4) + $versionNew
				Write-Host("New version of the Product is $productId")
				$projectgroup.ProductVersion = $productId
				$projectgroup.ProductId = [string]$Guid
			}
		}
		write-Host("Saving the xml File Now")
		$btdfprojxml.Save($BTDFProjFilePath);
	}
}
UpdateBTDFFile -BTDFProjFilePath $BTDFProjFilePath 
