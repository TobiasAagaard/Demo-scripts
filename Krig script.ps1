$cards = ( 2, 3, 4, 5, 6, 7, 8, 9, 10, "J", "D", "K", "A");
$cardType = ("spar", "Klør", "Hjerte", "Rude");



function Get-CardValue($cards) {
    switch($cards) {
        2 {return [int]$cards; break}
        3 {return [int]$cards; break}
        4 {return [int]$cards; break}
        5 {return [int]$cards; break}
        6 {return [int]$cards; break}
        7 {return [int]$cards; break}
        8 {return [int]$cards; break}
        9 {return [int]$cards; break}
        10 {return [int]$cards; break}
        "J" {return 11; break}
        "D" {return 12; break}
        "K" {return 13; break}
        "A" {return 14; break}
    }

}

$cardTypeRandomPlayer = Get-Random -InputObject $cardType;
$cardTypeRandomComputer = Get-Random -InputObject $cardType;

$playerCards = Get-Random  -InputObject $cards;
$playerValue = Get-CardValue $playerCards;

$computerCards = Get-Random -InputObject $cards;
$computerValue = Get-CardValue $computerCards;


Write-Host "Du har trukket $cardTypeRandomPlayer $playerValue"
Write-Host "Computeren har trukket $cardTypeRandomComputer $computerValue"



if ($playerValue -ge $computerValue) {
    Write-Host "Tillykke du vandt!!"
} elseif ($playerValue -lt $computerValue) {
    Write-Host "Du tabte!"
} else {
    Write-Host "Det blev uafgjort"
}


