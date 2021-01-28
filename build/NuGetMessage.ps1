param (
[string]$uri,
[string]$version,
[string]$nugeturl
)

$hash = @{
  message="Gerade haben wir die Version $($version) des T4 FileManager auf NuGet unter $($nugeturl)$($version) publiziert."
  url=$nugeturl
}

$JSON = $hash | convertto-json 
Write-Host $JSON
Invoke-WebRequest -Uri $uri -Method Post -Body $JSON -ContentType 'application/json'