
$date = Get-Date -Format "dd"

$folders = Get-ChildItem -Directory

mkdir -Path "$PSScriptRoot\$date" | Out-Null

foreach($folder in $folders)
{
    Move-Item -Path $folder -Destination "$PSScriptRoot\$date"
}
