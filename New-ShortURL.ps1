$clipbloard = Get-Clipboard

$body = @{
    url = $clipbloard
}

$JsonString = $body | ConvertTo-Json

$webPost = Invoke-WebRequest -Uri https://fozie.net -ContentType "application/json" -Method Post -Body $JsonString

Set-Clipboard -Value $webPost.Content