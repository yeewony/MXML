#----------------------------------------------------------------------#
#            아래 이름 항목을 본인의 이름에 맞게 수정하세요
#                  
#

$name = "여러분의 이름"

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
[string]$rootpath = $PSScriptRoot
#"\\10.1.8.4\windata\NEW_TEAM_1\defender\$month\$day"


#----------------------------------------------------------------------#
#                  
#                              코드
#
#----------------------------------------------------------------------#

$code = @"
    [DllImport("user32.dll")]
    public static extern bool BlockInput(bool fBlockIt);
"@

$userInput = Add-Type -MemberDefinition $code -Name UserInput -Namespace UserInput -PassThru

function Disable-UserInput($seconds) {
    $userInput::BlockInput($true)
    Start-Sleep $seconds
    $userInput::BlockInput($false)
}

function CaptureDefender
{
    Disable-UserInput -seconds 2 | Out-Null
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
    #Start-Job -Name Fullscanday -ScriptBlock { Start-MpScan -ScanType FullScan } | Out-Null
    #Wait-Job -Name Fullscanday | Out-Null
    CaptureDefender
}
else
{
    #Start-Job -Name Quickscanday -ScriptBlock { Start-MpScan -ScanType QuickScan } | Out-Null
    #Wait-Job -Name Quickscanday | Out-Null
    CaptureDefender
}




