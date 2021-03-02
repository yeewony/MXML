#확장자별로 파일 경로 찾기
#시간 추출
#시간 폴더 생성
#파일 이동

#v2
#인덱스 json 파일 생성


#시작하기.

$localpath = [String]$PSScriptRoot


#파일들 경로 갖고 오기

$wmvpath = Get-ChildItem -Path $localpath -Filter *.wmv | % {$_.FullName}
$resultzippath = Get-ChildItem -Path $localpath -Filter 점검결과_*.zip | % {$_.FullName}
$datazippath = Get-ChildItem -Path $localpath -Filter data*.zip  | % {$_.FullName}
$docxpath = Get-ChildItem -Path $localpath -Filter *.docx | % {$_.FullName}
$pdfpath = Get-ChildItem -Path $localpath -Filter *.pdf | % {$_.FullName}

#zip 파일 검사

mkdir -Path "tmp" | Out-Null

Expand-Archive $resultzippath -DestinationPath "$localpath\tmp"

if(!(Get-ChildItem -Path "$localpath\tmp" -Filter *.txt))
{
    Write-Host "점검결과.ZIP 파일 안에 바이러스 점검결과가 없습니다."
}
if(!(Get-ChildItem -Path "$localpath\tmp" -Filter *After.xml))
{
    Write-Host "점검결과.ZIP 파일 안에 Result_After.xml 파일이 없습니다."
}
if(!(Get-ChildItem -Path "$localpath\tmp" -Filter *Before.xml))
{
    Write-Host "점검결과.ZIP 파일 안에 Result_Before.xml 파일이 없습니다."
}

[xml]$xml = Get-Content (Get-ChildItem -Path "$localpath\tmp" -Filter *Before.xml | % {$_.FullName})

[int]$foldername = $xml.'PC-Check'.START_TIME.Split()[2].Split(":")[0]

if($foldername -lt 10)
{
    [string]$foldername = "0"+[string]$foldername
}
else
{
    [string]$foldername = [string]$foldername    
}

rmdir -Path "$localpath\tmp" -Force -Recurse


#바이러스 결과 체크