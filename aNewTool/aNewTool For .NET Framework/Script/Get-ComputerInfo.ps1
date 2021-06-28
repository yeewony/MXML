#if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator")) { Start-Process powershell.exe "-NoProfile -ExecutionPolicy Bypass -File `"$PSCommandPath`"" -Verb RunAs; exit } Out-Null

function EscapeJson {
    param(
        [String] $String)
    # removed: #-replace '/', '\/' `
    # This is returned 
    $String -replace '\\', '\\' -replace '\n', '\n' `
        -replace '\u0008', '\b' -replace '\u000C', '\f' -replace '\r', '\r' `
        -replace '\t', '\t' -replace '"', '\"'
}

# Meant to be used as the "end value". Adding coercion of strings that match numerical formats
# supported by JSON as an optional, non-default feature (could actually be useful and save a lot of
# calculated properties with casts before passing..).
# If it's a number (or the parameter -CoerceNumberStrings is passed and it 
# can be "coerced" into one), it'll be returned as a string containing the number.
# If it's not a number, it'll be surrounded by double quotes as is the JSON requirement.
function GetNumberOrString {
    param(
        $InputObject)
    if ($InputObject -is [System.Byte] -or $InputObject -is [System.Int32] -or `
        ($env:PROCESSOR_ARCHITECTURE -imatch '^(?:amd64|ia64)$' -and $InputObject -is [System.Int64]) -or `
        $InputObject -is [System.Decimal] -or `
        ($InputObject -is [System.Double] -and -not [System.Double]::IsNaN($InputObject) -and -not [System.Double]::IsInfinity($InputObject)) -or `
        $InputObject -is [System.Single] -or $InputObject -is [long] -or `
        ($Script:CoerceNumberStrings -and $InputObject -match $Script:NumberRegex)) {
        Write-Verbose -Message "Got a number as end value."
        "$InputObject"
    }
    else {
        Write-Verbose -Message "Got a string (or 'NaN') as end value."
        """$(EscapeJson -String $InputObject)"""
    }
}

function ConvertToJsonInternal {
    param(
        $InputObject, # no type for a reason
        [Int32] $WhiteSpacePad = 0)
    
    [String] $Json = ""
    
    $Keys = @()
    
    Write-Verbose -Message "WhiteSpacePad: $WhiteSpacePad."
    
    if ($null -eq $InputObject) {
        Write-Verbose -Message "Got 'null' in `$InputObject in inner function"
        $null
    }
    
    elseif ($InputObject -is [Bool] -and $InputObject -eq $true) {
        Write-Verbose -Message "Got 'true' in `$InputObject in inner function"
        $true
    }
    
    elseif ($InputObject -is [Bool] -and $InputObject -eq $false) {
        Write-Verbose -Message "Got 'false' in `$InputObject in inner function"
        $false
    }
    
    elseif ($InputObject -is [DateTime] -and $Script:DateTimeAsISO8601) {
        Write-Verbose -Message "Got a DateTime and will format it as ISO 8601."
        """$($InputObject.ToString('yyyy\-MM\-ddTHH\:mm\:ss'))"""
    }
    
    elseif ($InputObject -is [HashTable]) {
        $Keys = @($InputObject.Keys)
        Write-Verbose -Message "Input object is a hash table (keys: $($Keys -join ', '))."
    }
    
    elseif ($InputObject.GetType().FullName -eq "System.Management.Automation.PSCustomObject") {
        $Keys = @(Get-Member -InputObject $InputObject -MemberType NoteProperty |
            Select-Object -ExpandProperty Name)

        Write-Verbose -Message "Input object is a custom PowerShell object (properties: $($Keys -join ', '))."
    }
    
    elseif ($InputObject.GetType().Name -match '\[\]|Array') {
        
        Write-Verbose -Message "Input object appears to be of a collection/array type. Building JSON for array input object."
        
        $Json += "[`n" + (($InputObject | ForEach-Object {
            
            if ($null -eq $_) {
                Write-Verbose -Message "Got null inside array."

                " " * ((4 * ($WhiteSpacePad / 4)) + 4) + "null"
            }
            
            elseif ($_ -is [Bool] -and $_ -eq $true) {
                Write-Verbose -Message "Got 'true' inside array."

                " " * ((4 * ($WhiteSpacePad / 4)) + 4) + "true"
            }
            
            elseif ($_ -is [Bool] -and $_ -eq $false) {
                Write-Verbose -Message "Got 'false' inside array."

                " " * ((4 * ($WhiteSpacePad / 4)) + 4) + "false"
            }
            
            elseif ($_ -is [DateTime] -and $Script:DateTimeAsISO8601) {
                Write-Verbose -Message "Got a DateTime and will format it as ISO 8601."

                " " * ((4 * ($WhiteSpacePad / 4)) + 4) + """$($_.ToString('yyyy\-MM\-ddTHH\:mm\:ss'))"""
            }
            
            elseif ($_ -is [HashTable] -or $_.GetType().FullName -eq "System.Management.Automation.PSCustomObject" -or $_.GetType().Name -match '\[\]|Array') {
                Write-Verbose -Message "Found array, hash table or custom PowerShell object inside array."

                " " * ((4 * ($WhiteSpacePad / 4)) + 4) + (ConvertToJsonInternal -InputObject $_ -WhiteSpacePad ($WhiteSpacePad + 4)) -replace '\s*,\s*$'
            }
            
            else {
                Write-Verbose -Message "Got a number or string inside array."

                $TempJsonString = GetNumberOrString -InputObject $_
                " " * ((4 * ($WhiteSpacePad / 4)) + 4) + $TempJsonString
            }

        }) -join ",`n") + "`n$(" " * (4 * ($WhiteSpacePad / 4)))],`n"

    }
    else {
        Write-Verbose -Message "Input object is a single element (treated as string/number)."

        GetNumberOrString -InputObject $InputObject
    }
    if ($Keys.Count) {

        Write-Verbose -Message "Building JSON for hash table or custom PowerShell object."

        $Json += "{`n"

        foreach ($Key in $Keys) {

            # -is [PSCustomObject]) { # this was buggy with calculated properties, the value was thought to be PSCustomObject

            if ($null -eq $InputObject.$Key) {
                Write-Verbose -Message "Got null as `$InputObject.`$Key in inner hash or PS object."
                $Json += " " * ((4 * ($WhiteSpacePad / 4)) + 4) + """$Key"": null,`n"
            }

            elseif ($InputObject.$Key -is [Bool] -and $InputObject.$Key -eq $true) {
                Write-Verbose -Message "Got 'true' in `$InputObject.`$Key in inner hash or PS object."
                $Json += " " * ((4 * ($WhiteSpacePad / 4)) + 4) + """$Key"": true,`n"            }

            elseif ($InputObject.$Key -is [Bool] -and $InputObject.$Key -eq $false) {
                Write-Verbose -Message "Got 'false' in `$InputObject.`$Key in inner hash or PS object."
                $Json += " " * ((4 * ($WhiteSpacePad / 4)) + 4) + """$Key"": false,`n"
            }

            elseif ($InputObject.$Key -is [DateTime] -and $Script:DateTimeAsISO8601) {
                Write-Verbose -Message "Got a DateTime and will format it as ISO 8601."
                $Json += " " * ((4 * ($WhiteSpacePad / 4)) + 4) + """$Key"": ""$($InputObject.$Key.ToString('yyyy\-MM\-ddTHH\:mm\:ss'))"",`n"
                
            }

            elseif ($InputObject.$Key -is [HashTable] -or $InputObject.$Key.GetType().FullName -eq "System.Management.Automation.PSCustomObject") {
                Write-Verbose -Message "Input object's value for key '$Key' is a hash table or custom PowerShell object."
                $Json += " " * ($WhiteSpacePad + 4) + """$Key"":`n$(" " * ($WhiteSpacePad + 4))"
                $Json += ConvertToJsonInternal -InputObject $InputObject.$Key -WhiteSpacePad ($WhiteSpacePad + 4)
            }

            elseif ($InputObject.$Key.GetType().Name -match '\[\]|Array') {

                Write-Verbose -Message "Input object's value for key '$Key' has a type that appears to be a collection/array."
                Write-Verbose -Message "Building JSON for ${Key}'s array value."

                $Json += " " * ($WhiteSpacePad + 4) + """$Key"":`n$(" " * ((4 * ($WhiteSpacePad / 4)) + 4))[`n" + (($InputObject.$Key | ForEach-Object {

                    if ($null -eq $_) {
                        Write-Verbose -Message "Got null inside array inside inside array."
                        " " * ((4 * ($WhiteSpacePad / 4)) + 8) + "null"
                    }

                    elseif ($_ -is [Bool] -and $_ -eq $true) {
                        Write-Verbose -Message "Got 'true' inside array inside inside array."
                        " " * ((4 * ($WhiteSpacePad / 4)) + 8) + "true"
                    }

                    elseif ($_ -is [Bool] -and $_ -eq $false) {
                        Write-Verbose -Message "Got 'false' inside array inside inside array."
                        " " * ((4 * ($WhiteSpacePad / 4)) + 8) + "false"
                    }

                    elseif ($_ -is [DateTime] -and $Script:DateTimeAsISO8601) {
                        Write-Verbose -Message "Got a DateTime and will format it as ISO 8601."
                        " " * ((4 * ($WhiteSpacePad / 4)) + 8) + """$($_.ToString('yyyy\-MM\-ddTHH\:mm\:ss'))"""
                    }

                    elseif ($_ -is [HashTable] -or $_.GetType().FullName -eq "System.Management.Automation.PSCustomObject" `
                        -or $_.GetType().Name -match '\[\]|Array') {
                        Write-Verbose -Message "Found array, hash table or custom PowerShell object inside inside array."
                        " " * ((4 * ($WhiteSpacePad / 4)) + 8) + (ConvertToJsonInternal -InputObject $_ -WhiteSpacePad ($WhiteSpacePad + 8)) -replace '\s*,\s*$'
                    }

                    else {
                        Write-Verbose -Message "Got a string or number inside inside array."
                        $TempJsonString = GetNumberOrString -InputObject $_
                        " " * ((4 * ($WhiteSpacePad / 4)) + 8) + $TempJsonString
                    }

                }) -join ",`n") + "`n$(" " * (4 * ($WhiteSpacePad / 4) + 4 ))],`n"

            }
            else {

                Write-Verbose -Message "Got a string inside inside hashtable or PSObject."
                # '\\(?!["/bfnrt]|u[0-9a-f]{4})'

                $TempJsonString = GetNumberOrString -InputObject $InputObject.$Key
                $Json += " " * ((4 * ($WhiteSpacePad / 4)) + 4) + """$Key"": $TempJsonString,`n"

            }

        }

        $Json = $Json -replace '\s*,$' # remove trailing comma that'll break syntax
        $Json += "`n" + " " * $WhiteSpacePad + "},`n"

    }

    $Json

}

function ConvertTo-STJson {
    [CmdletBinding()]
    #[OutputType([Void], [Bool], [String])]
    Param(
        [AllowNull()]
        [Parameter(Mandatory=$True,
                   ValueFromPipeline=$True,
                   ValueFromPipelineByPropertyName=$True)]
        $InputObject,
        [Switch] $Compress,
        [Switch] $CoerceNumberStrings = $False,
        [Switch] $DateTimeAsISO8601 = $False)
    Begin{

        $JsonOutput = ""
        $Collection = @()
        # Not optimal, but the easiest now.
        [Bool] $Script:CoerceNumberStrings = $CoerceNumberStrings
        [Bool] $Script:DateTimeAsISO8601 = $DateTimeAsISO8601
        [String] $Script:NumberRegex = '^-?\d+(?:(?:\.\d+)?(?:e[+\-]?\d+)?)?$'
        #$Script:NumberAndValueRegex = '^-?\d+(?:(?:\.\d+)?(?:e[+\-]?\d+)?)?$|^(?:true|false|null)$'

    }

    Process {

        # Hacking on pipeline support ...
        if ($_) {
            Write-Verbose -Message "Adding object to `$Collection. Type of object: $($_.GetType().FullName)."
            $Collection += $_
        }

    }

    End {
        
        if ($Collection.Count) {
            Write-Verbose -Message "Collection count: $($Collection.Count), type of first object: $($Collection[0].GetType().FullName)."
            $JsonOutput = ConvertToJsonInternal -InputObject ($Collection | ForEach-Object { $_ })
        }
        
        else {
            $JsonOutput = ConvertToJsonInternal -InputObject $InputObject
        }
        
        if ($null -eq $JsonOutput) {
            Write-Verbose -Message "Returning `$null."
            return $null # becomes an empty string :/
        }
        
        elseif ($JsonOutput -is [Bool] -and $JsonOutput -eq $true) {
            Write-Verbose -Message "Returning `$true."
            [Bool] $true # doesn't preserve bool type :/ but works for comparisons against $true
        }
        
        elseif ($JsonOutput-is [Bool] -and $JsonOutput -eq $false) {
            Write-Verbose -Message "Returning `$false."
            [Bool] $false # doesn't preserve bool type :/ but works for comparisons against $false
        }
        
        elseif ($Compress) {
            Write-Verbose -Message "Compress specified."
            (
                ($JsonOutput -split "\n" | Where-Object { $_ -match '\S' }) -join "`n" `
                    -replace '^\s*|\s*,\s*$' -replace '\ *\]\ *$', ']'
            ) -replace ( # these next lines compress ...
                '(?m)^\s*("(?:\\"|[^"])+"): ((?:"(?:\\"|[^"])+")|(?:null|true|false|(?:' + `
                    $Script:NumberRegex.Trim('^$') + `
                    ')))\s*(?<Comma>,)?\s*$'), "`${1}:`${2}`${Comma}`n" `
              -replace '(?m)^\s*|\s*\z|[\r\n]+'
        }
        
        else {
            ($JsonOutput -split "\n" | Where-Object { $_ -match '\S' }) -join "`n" `
                -replace '^\s*|\s*,\s*$' -replace '\ *\]\ *$', ']'
        }
    
    }

}


$PSScriptRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition

$info = systeminfo /fo CSV | ConvertFrom-CSV | ConvertTo-STJson 

$info > "$PSScriptRoot\Systeminfo_Sorted.json"
systeminfo /fo csv | ConvertFrom-Csv > "$PSScriptRoot\systeminfo_CDATA.json"