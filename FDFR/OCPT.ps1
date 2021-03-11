#----------------------------------------------------------------------#
#            아래 이름 항목을 본인의 이름에 맞게 수정하세요
#                  
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
#오늘 날짜
$date = (Get-Date -Format "yyyyMMdd").ToString()
#일 날자
$day = (Get-Date -Format "dd").ToString()
#월 날짜
$month = (Get-Date -Format "MM").ToString()
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
    #윈도우디펜더 창 열기
    start-process windowsdefender://threat
    #스크린샷을 위한 대기
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


mkdirbyMM
CaptureDefender