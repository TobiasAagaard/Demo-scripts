function Calculator {

Write-Host "Dette er en lommeregner"
[float] $numb1 = Read-Host "tast første tal"
[float] $numb2 = Read-Host "tast andet tal"
        $operation = Read-Host "Vælg dit regneart (+, -, *, /)"
        $result = 0
      
      switch ($operation) {
        "+" {$result = $numb1 + $numb2; break}

        "-" {$result = $numb1 - $numb2; break}

        "*" {$result = $numb1 * $numb2; break}

        "/" {if ($numb2 -ne 0)   {
                $result = $numb1 / $numb2
        } else {
            $result = "Fejl, du kan ikke dividere med nul!"
        }; break} 

        default {$result = "Du skal bruge en anden regneart(+, -, *, /)"}

        }
      


    Write-Host "$result"
}

Calculator