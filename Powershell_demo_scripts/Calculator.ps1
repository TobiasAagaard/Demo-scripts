function Calculator {
    Write-Host "Dette er en lommeregner"
    [float] $numb1 = Read-Host "Tast første tal"
    $operation = Read-Host "Vælg din regneart (+, -, *, /, sqrt)"
    $result = 0

    if ($operation -ne "sqrt") {
        [float] $numb2 = Read-Host "Tast andet tal"
    }

    switch ($operation) {
        "+" {$result = $numb1 + $numb2; break}
        "-" {$result = $numb1 - $numb2; break}
        "*" {$result = $numb1 * $numb2; break}
        "/" {
            if ($numb2 -ne 0) {
                $result = $numb1 / $numb2
            } else {
                $result = "Fejl, du kan ikke dividere med nul!"
            }; break
        }
        "sqrt" {
            if ($numb1 -ge 0) {
                $result = [math]::Sqrt($numb1)
            } else {
                $result = "Fejl, du kan ikke tage kvadratroden af et negativt tal!"
            }; break
        }
        default {
            $result = "Du skal bruge en anden regneart (+, -, *, /, sqrt)"
        }
    }

    Write-Host "Resultat: $result"
}

Calculator