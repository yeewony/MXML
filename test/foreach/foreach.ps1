$todo = $todo1, $todo2, $todo3, $todo4

$todo1 = $true
$todo2 = $false
$todo3 = $false
$todo4 = $true

foreach ($num in 0..($todo.Count - 1))
{
    if($todo[$num] -eq $true)
    {
        $num += 1
        Set-Variable -Name "todo$num" -Value "Y"

    }
    else {
        $num += 1
        Set-Variable -Name "todo$num" -Value "N"
    }
}

$todo