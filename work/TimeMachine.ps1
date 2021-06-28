#if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator")) { Start-Process powershell.exe "-NoProfile -ExecutionPolicy Bypass -File `"$PSCommandPath`"" -Verb RunAs; exit } Out-Null


Write-Output "원격 지원 연결  => Value 값이 1이면 허용"
Set-ItemProperty -Path 'Registry::HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Control\Remote Assistance' -Name fAllowToGetHelp -Value 1

Write-Output "원격 데스크톱 연결 => Value 값이 0이면 허용"
Set-ItemProperty -Path 'Registry::HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Terminal Server' -Name fDenyTSConnections -Value 0

Write-Output "자동실행 설정 => Value 값이 1이면 설정됨"
Set-ItemProperty -Path 'Registry::HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\AutoplayHandlers' -Name DisableAutoplay -Value 0

Write-Output "화면 보호기 시간"
Set-ItemProperty -Path 'Registry::HKEY_CURRENT_USER\Control Panel\Desktop\' -Name ScreenSaveTimeout -Value 1000

Write-Output "화면 보호기 로그온 화면"
Set-ItemProperty -Path 'Registry::HKEY_CURRENT_USER\Control Panel\Desktop\' -Name ScreenSaverIsSecure -Value 0

Write-Output "화면 보호기 설정 삭제"
Remove-ItemProperty -Path 'Registry::HKEY_CURRENT_USER\Control Panel\Desktop' -Name SCRNSAVE.EXE


Write-Output "암호 유효 날짜 90일 설정하는것을 10일로"
#net accounts /maxpwage:10 #unlimited

Write-Output "기본공유"
New-SmbShare -Name "C$" -Path "C:\" -Description "기본 공유"
Set-ItemProperty -Path 'Registry::HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters\' -Name AutoShareWks -Value 1
