$filePath = 'C:\Users\tobia\OneDrive\Dokumenter\Datatekniker\Programmering\Powershell\Demo scripts\calc2.txt'

$problems = Get-Content $filePath

function CorrectCalc {
    foreach ($problem in $problems) {
        # Split linjen efter mellemrum
        $splitString = $problem -split ' '

        # Tjekker, at splitningen har givet de forventede elementer
        if ($splitString.Length -ge 5) {
            $operator = $splitString[3]
            [int]$number1 = $splitString[2]
            [int]$number2 = $splitString[4]
            [int]$sum = $splitString[0]

            # Beregn resultat baseret på operatoren
            if ($operator -eq "+") {
                $result = $number1 + $number2
            } elseif ($operator -eq "-") {
                $result = $number1 - $number2
            } elseif ($operator -eq "/") {
                $result = $number1 / $number2
            } elseif ($operator -eq "*") {
                $result = $number1 * $number2
            } else {
                Write-Host "Ukendt operator i: $problem"
                continue
            }

            # Sammenlign det beregnede resultat med det forventede
            if ($result -ne $sum) {
                Write-Host "Forkert resultat for: $problem. Forventet: $sum, Beregnet: $result"
            } 
        } else {
            Write-Host "Fejl i formatet for linje: $problem"
        }
    }
}

# Kald funktionen
CorrectCalc
