$filePath = 'C:\Users\tobia\OneDrive\Dokumenter\Datatekniker\Programmering\Powershell\Demo scripts\calc2.txt';

$problems = Get-Content $filePath

foreach ($problem in $problems) {
    
    $parts = $problem -split ' '
    
    $calculation = "$($parts[2]) $($parts[3]) $($parts[4])"
    
    $expectedResult = [int]$parts[0]
  
    $actualResult = Invoke-Expression $calculation

    if ($actualResult -ne $expectedResult) {
        Write-Output "Fejl i regnestykket: $problem (Forventet: $expectedResult, Faktisk: $actualResult)"
    }
}
