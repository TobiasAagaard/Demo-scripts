# Definerer stien til en tekstfil, som indeholder matematiske problemer.
$filePath = 'C:\Users\tobia\OneDrive\Dokumenter\Datatekniker\Programmering\Powershell\Demo scripts\calc2.txt'

# Henter indholdet af filen, hvor hvert problem repræsenteres som en linje i filen.
$problems = Get-Content $filePath

# Løkke, der går igennem hvert problem i filen.
foreach ($problem in $problems) {
    
    # Deler hvert problem op i dele baseret på mellemrum.
    $parts = $problem -split ' '
    
    # Samler regnestykket fra delene (operationen), som senere skal evalueres.
    $calculation = "$($parts[2]) $($parts[3]) $($parts[4])"
    
    # Konverterer den første del af problemet til et heltal (forventet resultat).
    $expectedResult = [int]$parts[0]
  
    # Udfører selve beregningen ved hjælp af Invoke-Expression, som evaluerer regnestykket.
    $actualResult = Invoke-Expression $calculation

    # Sammenligner det faktiske resultat med det forventede resultat.
    if ($actualResult -ne $expectedResult) {
        # Hvis resultatet er forkert, skrives en fejlbesked ud, der viser både forventet og faktisk resultat.
        Write-Output "Fejl i regnestykket: $problem (Forventet: $expectedResult, Faktisk: $actualResult)"
    }
}
