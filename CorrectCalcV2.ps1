$filePath = 'C:\Users\tobia\OneDrive\Dokumenter\Datatekniker\Programmering\Powershell\Demo scripts\calc2.txt'

$problems = get-content $filePath

function CorrectCalc () {

    foreach ($problem in $problems) {
    
    $splitString = $problems -split '';

    $operator = $splitString[3]
    [int]$number1 = $splitString[2]
    [int]$number2 = $splitString[4]
    [int]$sum = $splitString[0]

    if ($operator -eq "+") {
        $result = $number1 + $number2
    } elseif ($operator -eq "-") {
        $result = $number1 - $number2
    } elseif ($operator -eq "/") {
        $result = $number1 / $number2
    } elseif ($operator -eq "*") {
        $result = $number1 -eq $number2
    }

    if ($result -eq $sum) {
        Write-Host "Det er rigtigt"
    } else {
        Write-Host "De"
    }
}
}