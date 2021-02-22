#Addtype
[System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms")
Add-Type -AssemblyName PresentationFramework
[System.Windows.Forms.Application]::EnableVisualStyles()

# ------------------------------------------------------------------------

# GUI SOURCE CODE

# ------------------------------------------------------------------------

$gui_xmal = @'
<Window
xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
Title="MainWindow" Height="450" Width="800">
<Grid>
<ToggleButton x:Name="Togle1" Width="200" Height="100" BorderThickness="0" Content="예스" Margin="288,193,304,126" OpacityMask="#FFE43333"/>
</Grid>
</Window>
'@

[xml]$gui_xmal = $gui_xmal -replace 'mc:Ignorable="d"','' -replace "x:N",'N' -replace '^<Win.*', '<Window'

$xamlreader = (New-Object System.Xml.XmlNodeReader $gui_xmal)
$GUI = [Windows.Markup.XamlReader]::Load($xamlreader)

$gui_xmal.SelectNodes("//*[@Name]") | ForEach-Object { Set-Variable -Name ($_.Name) -Value $GUI.FindName($_.Name) }

$Togle1.Add_Click({ TogleTest })

function TogleTest {
    if($Togle1.IsChecked -eq $true)
    {
        $Togle1.Content = "예쓰"
    }
    else {
        $Togle1.Content = "노오오오우"
    }
}



$GUI.ShowDialog() | out-null