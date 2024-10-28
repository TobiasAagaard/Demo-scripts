# Bed brugeren om en sætning
$sætning = Read-Host "Skriv en sætning"

# Udskriv sætningen baglæns
$baglæns = -join ($sætning.ToCharArray() | ForEach-Object { $_ })[-1..0]
Write-Host "`nSætningen baglæns: $baglæns"

# Konverter til LEET speak
$leetSætning = $sætning -replace 'a', '4' -replace 'e', '3' -replace 'i', '1' -replace 'o', '0' -replace 's', '5' -replace 't', '7'
Write-Host "LEET speak: $leetSætning"

# Konverter til store og små bogstaver
Write-Host "Store bogstaver: $($sætning.ToUpper())"
Write-Host "Små bogstaver: $($sætning.ToLower())"