﻿
#v2
#인덱스 json 파일 생성


#시작하기.

$localpath = $PSScriptRoot
$global:Err = $null
$global:foldername = $null

#-----------------------------------------------------------------------------#
#
#                               파일 경로 추출
#
#-----------------------------------------------------------------------------#



$wmvpath = Get-ChildItem -Path $localpath -Filter *.wmv | % {$_.FullName}
$resultzippath = Get-ChildItem -Path $localpath -Filter 점검결과_*.zip | % {$_.FullName}
$datazippath = Get-ChildItem -Path $localpath -Filter data*.zip  | % {$_.FullName}
$docxpath = Get-ChildItem -Path $localpath -Filter *.docx | % {$_.FullName}
$pdfpath = Get-ChildItem -Path $localpath -Filter *.pdf | % {$_.FullName}


if($wmvpath -eq $null)
{
    Write-Host "동영상이 없습니다."
    Pause
    exit
}
if($resultzippath -eq $null)
{   Write-Host "점검결과.ZIP 파일이 없습니다." 
    Pause
    exit
}

if($docxpath -eq $null)
{
    Write-Host "보고서 파일이 없습니다." 
    Pause
    exit
}



#-----------------------------------------------------------------------------#
#
#                               ZIP 파일 검사
#
#-----------------------------------------------------------------------------#

#임시 폴더 생성 및 압축 해제

mkdir -Path "tmp" | Out-Null
Expand-Archive $resultzippath -DestinationPath "$localpath\tmp" | Out-Null

#zip 파일 갯수 확인 검사
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


#Virus_Result.txt 파일 검사
$virustxt = Get-Content (Get-ChildItem -Path "$localpath\tmp" -Filter *.txt | % {$_.FullName})

$vRsltbf = ($virustxt | Select-String -Pattern '(?<=점검 대상 객체 :\s).+').Matches.Value.Trim()
$vRsltaf = ($virustxt | Select-String -Pattern '(?<=정상 파일 :\s).+').Matches.Value.Trim()

if($vRsltbf -ne $vRsltaf)
{
    Write-Host "Virus Result 검사 파일 갯수가 다릅니다. Virus_Result_Check.txt 파일을 확인하세요."
}


#-----------------------------------------------------------------------------#
#
#                              시간 폴더 생성
#
#-----------------------------------------------------------------------------#

#시간 값 가져오기
[xml]$xml = Get-Content (Get-ChildItem -Path "$localpath\tmp" -Filter *Before.xml | % {$_.FullName})

[int]$foldername = $xml.'PC-Check'.START_TIME.Split()[1].Split(":")[0]

if($foldername -eq 0)
{
    [int]$foldername = $xml.'PC-Check'.START_TIME.Split()[2].Split(":")[0]
}

if($foldername -lt 10)
{
    [string]$foldername = "0"+[string]$foldername
}
else
{
    [string]$foldername = [string]$foldername
}

$foldername

#시간 폴더 생성
mkdir -Path "$localpath\$foldername" | Out-Null

#임시폴더 삭제
rmdir -Path "$localpath\tmp" -Force -Recurse | Out-Null


#-----------------------------------------------------------------------------#
#
#                               파일 옮기기
#
#-----------------------------------------------------------------------------#

Move-Item -Path $wmvpath -Destination "$localpath\$foldername" | Out-Null
Move-Item -Path $resultzippath -Destination "$localpath\$foldername" | Out-Null
Move-Item -Path $datazippath -Destination "$localpath\$foldername" | Out-Null
Move-Item -Path $docxpath -Destination "$localpath\$foldername" | Out-Null
Move-Item -Path $pdfpath -Destination "$localpath\$foldername" | Out-Null

