
$bfxml = Get-ChildItem -Path $PSScriptRoot -Filter *before.xml | % {$_.FullName}
$afxml = Get-ChildItem -Path $PSScriptRoot -Filter *after.xml | % {$_.FullName}

Move-Item -path $bfxml -Destination "$PSScriptRoot\res"
Move-Item -path $afxml -Destination "$psscriptroot\res"

#$bfxml = Get-ChildItem -Path "$psscriptroot\res" -Filter *before.xml
#$afxml = Get-ChildItem -Path "$psscriptroot\res" -Filter *after.xml

Set-Location res

.\Android_Report.exe

Start-Sleep -Seconds 1

Set-Location $PSScriptRoot

$1 = Get-ChildItem -Path "$psscriptroot\res" -Filter *.zip | % {$_.FullName}
$2 = Get-ChildItem -Path "$psscriptroot\res" -Filter *.docx | % {$_.FullName}


Move-Item -Path $1 -Destination $PSScriptRoot
Move-Item -path $2 -Destination $PSScriptRoot
