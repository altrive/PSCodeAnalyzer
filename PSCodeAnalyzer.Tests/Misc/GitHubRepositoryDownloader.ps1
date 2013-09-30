$ErrorActionPreference ="Stop"

function Main
{
	$results = Find-GutHubRepository -Filter "language:powershell&sort=stars" -Verbose
 
	Write-Host ("Total Repositry Count    : {0}" -f $results.total_count)
	Write-Host ("Returned Repository Count: {0}" -f $results.items.Count)
	$results.items | select name, description,html_url,fork | Out-GridView -Wait:$false

	DownloadRepositoryContent

	GetTestTemplates | clip
}



function Find-GutHubRepository
{
    [CmdletBinding()]
    param (
        [string] $Filter
    )

    $ErrorActionPreference = "Stop"

    $requestUrl = "https://api.github.com/search/repositories?q={0}&page=1&per_page=100" -f $Filter #Max per_page value is 100
    :while while ($true)
    {
        $request = [Net.WebRequest]::CreateHttp($requestUrl)
        $request.Method = "Get"
        $request.UserAgent = "Awesome-Octocat-App" #Required for Github REST API <http://developer.github.com/v3/#user-agent-required>
        $request.Accept = "application/vnd.github.preview" #Required for Preview API
     
        try {
            try {
                Write-Verbose ("QueryUrl: {0}" -f [Uri]::UnescapeDataString($requestUrl))
                $response = [Net.HttpWebResponse] $request.GetResponse()
            }
            catch [Net.WebException]{
                $response = $_.Exception.Response
            }

            switch ([int] $response.StatusCode)
            {
                "200"{
                    $stream = $response.GetResponseStream()
                    $sr = New-Object IO.StreamReader($stream)
                    $resultText = $sr.ReadToEnd()
                                 
                    $result = ConvertFrom-Json $resultText
                    $result | Write-Output
                             
                    #TODO: handle "X-RateLimit-Reset" response appropriately
                    if ($response.Headers["X-RateLimit-Remaining"] -eq "0"){
                        Write-Verbose "X-RateLimit-Remaining is 0. wait 60 seconds"
                        sleep 60
                    }

                    #Check next page URL
                    $links = $response.Headers["Link"].Split(",")
                    foreach ($link in $links)
                    {
                        if ($link.Trim() -match '^<(.*)>; rel="next"$')
                        {
                            $requestUrl = $matches[1]
                            continue while
                        }
                    }
                    break while #no nextpage 
                }
                "403"{ #For unauthenticated requests, up to 5 requests per minute.
                    Write-Verbose "Exceed GitHub API RateLimit. wait 10 seconds"
                    sleep 10
                    continue
                }
                "404"{
                    break while;
                }
                "422"{
                    Write-Warning "Unexpected HttpResponseCode(422 Unprocessable Entity) returned, stop enumerate repository"
                    break while;
                }
                default{
                    throw "Unexpected HttpResponseCode:" + $response.StatusCode
                }
            }
        }
        finally {
            if ($response -ne $null){
                $response.Dispose()
            }
            if ($stream -ne $null){
                $stream.Dispose()
            }
            if ($sr -ne $null){
                $sr.Dispose()
            }
        }
    } #while
}



function DownloadRepositoryContent
{
	Add-Type -Assembly System.IO.Compression.FileSystem

	$downloadDir = "C:\Temp\Github"
	Write-Host ("Download files to: " + $downloadDir)
	(New-Object IO.FileInfo($downloadDir)).Directory.Create();

	foreach($item in $results.items)
	{
		if($item.full_name -eq "chrisdee/Tools"){
			continue #Size is too large
		}

		$fullname = $item.full_name.Replace("/","_")
		$downloadURL = "{0}/archive/{1}.zip" -f $item.html_url,$item.default_branch
		$downloadFilePath = Join-Path $downloadDir ("{0}.zip" -f $fullname)
		$extractPath = Join-Path $downloadDir $fullName

		if(Test-Path $extractPath){
			#Write-Host ("Skip: "+ $fullname)
			continue
		}

		if(!(Test-Path $downloadFilePath))
		{
			#Download zip file
			try{     
				$retryCount = 5
				for($i=0; $i -lt $retryCount;++$i){         
					$wc = New-Object Net.WebClient
					try{
						Write-Progress -Activity "Download"  -Status "RetryCount=$i : $downloadURL"
						$wc.DownloadFile($downloadURL, $downloadFilePath)
						sleep 1
						#Start-BitsTransfer -Source $downloadURL -Destination $downloadFilePath -DisplayName $downloadURL
						break
					}
					catch{
						if($i -ge $retryCount){
							throw
						}
						sleep 10
						continue
					}
				} 
			}catch{
				Write-Host ("Download Error:" +$downloadURL)
				continue
			}
			finally{
				Write-Progress -Activity "Download" -Completed
				$wc.Dispose()
			}
		}
    
		#Unzip files
		try{
			(New-Object IO.FileInfo($extractPath)).Directory.Create();
			[IO.Compression.ZipFile]::ExtractToDirectory($downloadFilePath, $extractPath)
		}catch{
			Write-Host ("Unzip Error:" + $downloadURL)
			continue
    }

	#Remove unnecessary files
	Get-ChildItem -Path $extractPath  -Exclude "*.ps1","*.psm1" -File -Recurse | Remove-Item

    #Delete zip file
    Remove-Item $downloadFilePath
}


function GetTestTemplates
{
	$sb = New-Object Text.StringBuilder
	foreach($item in $results.items)
	{
		$foldername = $item.full_name.Replace("/","_")
		$fullname = $item.full_name.Replace("/","_").Replace("-","_").Replace(".","_")

		$sb.AppendLine("[TestMethod]") > $null
		$sb.AppendLine("public void GitHub_$fullname()") > $null
		$sb.AppendLine("{") > $null
		$sb.AppendLine('var downloadUrl = "{0}";' -f $item.html_url) > $null
		$sb.AppendLine('TestFiles("{0}", downloadUrl);' -f $foldername) > $null
		$sb.AppendLine("}") > $null
		$sb.AppendLine() > $null
	}
	return $sb.ToString()
}


. Main