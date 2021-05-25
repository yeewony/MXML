#test

$com = Get-Content -Path "$PSScriptRoot\command" -Raw

$com

$converted = [System.Management.Automation.ScriptBlock]::Create($com)

$converted

& $converted

# Function Invoke-FileAsScript {
#     Param (
#         [CmdletBinding()]
#         [ValidateScript({
#             If(Test-Path $_){$true}else{throw "Invalid path given: $_"}
#         })]
#         [string]$Path
#     )
#         $AnyFile = Get-Content -Path $Path -Raw
#         $ScriptBlock = [System.Management.Automation.ScriptBlock]::Create($AnyFile)
#         & $ScriptBlock
#     }
    
#     Invoke-FileAsScript -Path C:\Temp\Text.txt