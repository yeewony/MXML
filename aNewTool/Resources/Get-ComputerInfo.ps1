#if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator")) { Start-Process powershell.exe "-NoProfile -ExecutionPolicy Bypass -File `"$PSCommandPath`"" -Verb RunAs; exit } Out-Null

$PSScriptRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition

#SYSTEMINFO
$systeminfo = Systeminfo /fo csv | ConvertFrom-Csv

#IPCONFIG /ALL
$ipconfigAll = ipconfig /all

#
$netstart = net start

$info = $systeminfo | ConvertTo-STJson

$info > "$PSScriptRoot\Systeminfo.json"
$systeminfo > "$PSScriptRoot\systeminfo_CDATA.json"
$ipconfigAll > "$PSScriptRoot\ipconfig.json"
$netstart > "$PSScriptRoot\netstart.json"