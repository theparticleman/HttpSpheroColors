for ($i=0; $i -lt 300; $i++) {
    $red = Get-Random -Minimum 0 -Maximum 256
    $green = Get-Random -Minimum 0 -Maximum 256
    $blue = Get-Random -Minimum 0 -Maximum 256

    $body = "red=$red&green=$green&blue=$blue"
    Invoke-WebRequest http://localhost -Method POST -Body $body
}