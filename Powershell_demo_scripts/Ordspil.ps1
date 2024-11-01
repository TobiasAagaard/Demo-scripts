# Bed brugeren om en sætning
$sætning = Read-Host "Skriv en sætning"


# Konverter til LEET speak
$leetSætning = $sætning -replace 'a', '4' -replace 'e', '3' -replace 'i', '1' -replace 'o', '0' -replace 's', '5' -replace 't', '7'
Write-Host "LEET speak: $leetSætning"

# Konverter til store og små bogstaver
Write-Host "Store bogstaver: $($sætning.ToUpper())"
Write-Host "Små bogstaver: $($sætning.ToLower())"