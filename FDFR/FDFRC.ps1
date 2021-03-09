#----------------------------------------------------------------------#
#                   아래 항목을 잘 입력하세요.
#                  팀 ex) 1팀 => $team ="1"
#

$name = "이asdf름"
$team = "1"

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
#월 날짜
$month = (Get-Date -Format "MM").ToString()
#저장경로
$filename = "$date"+"_"+"$name.png"
[string]$rootpath = "\\10.1.8.4\windata\NEW_TEAM_$team\defender\$month"


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
    Get-Clipboard -Format Image | ForEach-Object -MemberName Save -ArgumentList "$rootpath\$filename"
    #디펜더 창 끄기
    $defender = Get-Process -Name "sec*ui"
    $defender.Kill()
}


function mkdirbyMM
{
    #폴더 쳌킹
    if(![System.IO.File]::Exists("$rootpath"))
    {
        New-Item -ItemType Directory -Path "$rootpath"
    }
}

#작업 시작
if($isWednesday -eq 3)
{
    Start-Job -Name Fullscanday -ScriptBlock { Start-MpScan -ScanType FullScan } | Out-Null
    Wait-Job -Name Fullscanday | Out-Null
    mkdirbyMM
    CaptureDefender
}
else
{
    Start-Job -Name Quickscanday -ScriptBlock { Start-MpScan -ScanType QuickScan } | Out-Null
    Wait-Job -Name Quickscanday | Out-Null
    mkdirbyMM
    CaptureDefender
}




