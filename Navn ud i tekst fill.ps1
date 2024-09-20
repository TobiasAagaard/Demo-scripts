$first = Read-Host "Tast dit fornavn";
[int] $age = Read-Host "Tast dit din alder";




$line = "$first,$age";
$array = $line.split(",");


$array | Out-File -FilePath C:\Users\tobia\OneDrive\Skrivebord\users.txt









                     