
echo ".....####...##..##..#####....####...##...##..######.....";
echo "....##..##..##..##..##..##..##..##..###.###..##.........";
echo "....##......######..#####...##..##..##.#.##..####.......";
echo "....##..##..##..##..##..##..##..##..##...##..##.........";
echo ".....####...##..##..##..##...####...##...##..######.....";
echo ".................................................       ";
echo ".#####...######..######..#####...######...####...##..##.";
echo ".##..##..##......##......##..##..##......##......##..##.";
echo ".#####...####....####....#####...####.....####...######.";
echo ".##..##..##......##......##..##..##..........##..##..##.";
echo ".##..##..######..##......##..##..######...####...##..##.";
echo "...................................Powered by 11217.....";


write-host ""
write-host ""
write-host ""
write-host "크롬을 9분에 한번씩 새로고침 합니다"
write-host ""
write-host "###############참고 사항################"
write-host ""
write-host "   1. 여러 탭의 경우는 현재 안됩니다."
write-host "   2. 시간조절 안됩니다."
Write-Host "   3. 시크릿 탭은 작동 아마 안될겁니다."
Write-Host "   4. 켜져 있어야 작동합니다. 끄면 안됨."
Write-Host "   5. 이용해주셔서 감사합니다."
write-host ""
write-host "########################################"
write-host ""




















































































Pause
$time = 540
$count = 1


clear






































































write-host "스크립트 동작중... 종료 금지"
write-host "9분 마다 크롬을 새로고침 합니다."


while(1)
{
    
    Start-Sleep -Seconds $time
    $wshell = New-Object -ComObject wscript.shell 
    if($wshell.AppActivate('Chrome'))
    {
    Start-Sleep 1
    $wshell.SendKeys('{F5}')
    Start-Sleep -Milliseconds 300
    $wshell.SendKeys('^{Tab}')
    Start-Sleep -Milliseconds 300
    $wshell.SendKeys('{F5}')
    Start-Sleep -Milliseconds 300
    $wshell.SendKeys('^{Tab}')
    Start-Sleep -Milliseconds 300
    write-host "오늘 새로고침을 $count 회 했습니다."
    $count++
    }
    else { break; }
}