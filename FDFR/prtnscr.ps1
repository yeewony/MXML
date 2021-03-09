#----------------------------------------------------------------------#
#                   아래 "  "에 이름을 입력 하세요
#

$name = "이름"

#
#
#----------------------------------------------------------------------#




















#----------------------------------------------------------------------#
#                  
#                            변수와 환경 설정
#
#----------------------------------------------------------------------#


#윈도우 DLL 로딩
[void][reflection.assembly]::loadwithpartialname("system.windows.forms")
#수요일엔 풀스캔
$isWednesday = [int](Get-Date).DayOfWeek
#오늘 날짜
$date = (Get-Date -Format "yyyyMMdd").ToString()
#저장경로
#임시
[string]$temppath = ("$PSScriptRoot\$date"+"_"+"$name.png") 
#실제
[string]$savepath = "\\10.1.8.4\windata\NEW_TEAM_1\defender"


#----------------------------------------------------------------------#
#                  
#                              코드
#
#----------------------------------------------------------------------#

function CaptureDefender
{
    #윈도우디펜더 창 열기
    start-process windowsdefender://threat
    #스크린샷을 위한 작업
    Start-Sleep -s 1
    #프린트스크린
    [system.windows.forms.sendkeys]::sendwait('%{PRTSC}')
    #클립보드에 붙이고 이름 출력
    Get-Clipboard -Format Image | ForEach-Object -MemberName Save -ArgumentList ("$PSScriptRoot\$date"+"_"+"$name.png")
    #디펜더 창 끄기
    tskill SecHealthUI
}


#작업 시작
if($isWednesday -eq 3)
{
    #Start-Job -Name Fullscanday -ScriptBlock {}
    #Wait-Job -Name Fullscanday
    CaptureDefender
}
else
{
    #Start-Job -Name Quickscanday -ScriptBlock {}
    #Wait-Job -Name Quickscanday
    CaptureDefender
}




