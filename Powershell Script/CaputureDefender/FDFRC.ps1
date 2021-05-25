#   ________  ________  ________  _________  ___  ___  ________  _______               
#  |\   ____\|\   __  \|\   __  \|\___   ___\\  \|\  \|\   __  \|\  ___ \              
#  \ \  \___|\ \  \|\  \ \  \|\  \|___ \  \_\ \  \\\  \ \  \|\  \ \   __/|             
#   \ \  \    \ \   __  \ \   ____\   \ \  \ \ \  \\\  \ \   _  _\ \  \_|/__           
#    \ \  \____\ \  \ \  \ \  \___|    \ \  \ \ \  \\\  \ \  \\  \\ \  \_|\ \          
#     \ \_______\ \__\ \__\ \__\        \ \__\ \ \_______\ \__\\ _\\ \_______\         
#      \|_______|\|__|\|__|\|__|         \|__|  \|_______|\|__|\|__|\|_______|         
#
#                   아래 이름 항목을 본인의 이름에 맞게 수정하세요

                             $name = "여러분의 이름"

#   ________  _______   ________ _______   ________   ________  _______   ________     
#  |\   ___ \|\  ___ \ |\  _____\\  ___ \ |\   ___  \|\   ___ \|\  ___ \ |\   __  \    
#  \ \  \_|\ \ \   __/|\ \  \__/\ \   __/|\ \  \\ \  \ \  \_|\ \ \   __/|\ \  \|\  \   
#   \ \  \ \\ \ \  \_|/_\ \   __\\ \  \_|/_\ \  \\ \  \ \  \ \\ \ \  \_|/_\ \   _  _\  
#    \ \  \_\\ \ \  \_|\ \ \  \_| \ \  \_|\ \ \  \\ \  \ \  \_\\ \ \  \_|\ \ \  \\  \| 
#     \ \_______\ \_______\ \__\   \ \_______\ \__\\ \__\ \_______\ \_______\ \__\\ _\ 
#      \|_______|\|_______|\|__|    \|_______|\|__| \|__|\|_______|\|_______|\|__|\|__|
#                                                                                      
#                                                                                      



























































































#----------------------------------------------------------------------#
#                  
#                              환경 설정
#
#----------------------------------------------------------------------#
#if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator")) { Start-Process powershell.exe "-NoProfile -ExecutionPolicy Bypass -File `"$PSCommandPath`"" -Verb RunAs; exit } Out-Null

$t = '[DllImport("user32.dll")] public static extern bool ShowWindow(int handle, int state);'
add-type -name win -member $t -namespace native
[native.win]::ShowWindow(([System.Diagnostics.Process]::GetCurrentProcess() | Get-Process).MainWindowHandle, 0)

$host.UI.RawUI.WindowTitle = "디펜더는 나의 원쑤!"

#윈도우 DLL 로딩
[void][reflection.assembly]::loadwithpartialname("system.windows.forms")
[void][System.Reflection.Assembly]::LoadWithPartialName("Microsoft.VisualBasic")
#수요일엔 풀스캔
$isWednesday = [int](Get-Date).DayOfWeek
#오늘 날짜
$date = (Get-Date -Format "yyyyMMdd").ToString()
#월 날짜
$month = (Get-Date -Format "MM").ToString()
#일 날짜
$day = (Get-Date -Format "dd").ToString()
#저장경로
$filename = "$date"+"_"+"$name.png"
[string]$rootpath = "\\10.1.8.4\windata\NEW_TEAM_1\defender\$month\$day"



#----------------------------------------------------------------------#
#                  
#                              코드
#
#----------------------------------------------------------------------#

function CaptureDefender
{
    #캡쳐 시작 메세지 박스
    [Microsoft.VisualBasic.Interaction]::MsgBox("점검이 끝났습니다.`n확인을 누르면 캡처를 시작합니다.", "SystemModal,Information", "점검 완료")
    #윈도우디펜더 창 열기
    start-process windowsdefender://threat 
    #스크린샷을 위한 작업
    Start-Sleep -s 1
    #프린트스크린
    [system.windows.forms.sendkeys]::sendwait('%{PRTSC}')
    #클립보드에 붙이고 이름 출력
    Get-Clipboard -Format Image | ForEach-Object -MemberName Save -ArgumentList "$rootpath\$filename"
    #디펜더 창 끄기
    $defender = Get-Process -Name "sec*ui"
    $defender.Kill()
}

#작업 시작
if($isWednesday -eq 3)
{
    Start-Job -Name Fullscanday -ScriptBlock { Start-MpScan -ScanType FullScan } | Out-Null
    Wait-Job -Name Fullscanday | Out-Null
    CaptureDefender
}
else
{
    Start-Job -Name Quickscanday -ScriptBlock { Start-MpScan -ScanType QuickScan } | Out-Null
    Wait-Job -Name Quickscanday | Out-Null
    CaptureDefender
}




