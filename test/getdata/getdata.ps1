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
        Title="MXML" Height="533" Width="703" Background="#FFC1C1C1" ResizeMode="NoResize" WindowStartupLocation="CenterScreen" FontSize="10">
    <Grid>
        <Rectangle HorizontalAlignment="Left" Height="274" Margin="10,215,0,0" VerticalAlignment="Top" Width="317" Fill="#FF878787"/>
        <Label Content="시작 시간" HorizontalAlignment="Left" Margin="10,10,0,0" VerticalAlignment="Top" Height="25"/>
        <Label Content="종료 시간" HorizontalAlignment="Left" Margin="10,40,0,0" VerticalAlignment="Top" Height="25"/>
        <Label Content="OS 버전" HorizontalAlignment="Left" Margin="10,70,0,0" VerticalAlignment="Top" Height="25"/>
        <Label Content="모델명" HorizontalAlignment="Left" Margin="10,100,0,0" VerticalAlignment="Top" Height="25"/>
        <Label Content="제조사" HorizontalAlignment="Left" Margin="10,130,0,0" VerticalAlignment="Top" Height="25"/>
        <Label Content="통신사" HorizontalAlignment="Left" Margin="10,160,0,0" VerticalAlignment="Top" Height="25"/>
        <TextBox x:Name="tb_StartTime" HorizontalAlignment="Left" Height="25" Margin="72,10,0,0" VerticalAlignment="Top" Width="255" VerticalContentAlignment="Center" HorizontalScrollBarVisibility="Disabled" BorderThickness="0"/>
        <TextBox x:Name="tb_EndTime" HorizontalAlignment="Left" Height="25" Margin="72,40,0,0" VerticalAlignment="Top" Width="255" VerticalContentAlignment="Center" HorizontalScrollBarVisibility="Disabled" BorderThickness="0"/>
        <TextBox x:Name="tb_OSVer" HorizontalAlignment="Left" Height="25" Margin="72,70,0,0" VerticalAlignment="Top" Width="255" VerticalContentAlignment="Center" HorizontalScrollBarVisibility="Disabled" BorderThickness="0"/>
        <TextBox x:Name="tb_ModelName" HorizontalAlignment="Left" Height="25" Margin="72,100,0,0" VerticalAlignment="Top" Width="255" VerticalContentAlignment="Center" HorizontalScrollBarVisibility="Disabled" BorderThickness="0"/>
        <TextBox x:Name="tb_Manuf" HorizontalAlignment="Left" Height="25" Margin="72,130,0,0" VerticalAlignment="Top" Width="255" VerticalContentAlignment="Center" HorizontalScrollBarVisibility="Disabled" BorderThickness="0"/>
        <TextBox x:Name="tb_Carrier" HorizontalAlignment="Left" Height="25" Margin="72,160,0,0" VerticalAlignment="Top" Width="255" VerticalContentAlignment="Center" HorizontalScrollBarVisibility="Disabled" BorderThickness="0"/>
        <Label Content="점검결과 입력" HorizontalAlignment="Left" Margin="10,212,0,0" VerticalAlignment="Top" FontSize="12" FontWeight="Bold" FontStyle="Italic"/>
        <Label Content="* 스마트폰 잠금설정" HorizontalAlignment="Left" Margin="10,243,0,0" VerticalAlignment="Top" Height="30" VerticalContentAlignment="Center"/>
        <Label Content="* 최신 보안 업데이트" HorizontalAlignment="Left" Margin="10,313,0,0" VerticalAlignment="Top" Height="30" VerticalContentAlignment="Center"/>
        <Label Content="* 개발자 옵션 활성화" HorizontalAlignment="Left" Margin="10,348,0,0" VerticalAlignment="Top" Height="30" VerticalContentAlignment="Center"/>
        <Label Content="* 앱 권한 관리" HorizontalAlignment="Left" Margin="10,383,0,0" VerticalAlignment="Top" Height="30" VerticalContentAlignment="Center"/>
        <Label Content="* 백신 설치" HorizontalAlignment="Left" Margin="10,453,0,0" VerticalAlignment="Top" Height="30" VerticalContentAlignment="Center"/>
        <Label Content="* 구글 2단계 인증 활성화" HorizontalAlignment="Left" Margin="10,418,0,0" VerticalAlignment="Top" Height="30" VerticalContentAlignment="Center"/>
        <ToggleButton x:Name="tgle_bf_01" Width="40" Height="30" BorderThickness="0" Content="취약" Margin="203,243,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <ToggleButton x:Name="tgle_bf_03" Width="40" Height="30" BorderThickness="0" Content="취약" Margin="203,313,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <ToggleButton x:Name="tgle_bf_04" Width="40" Height="30" BorderThickness="0" Content="취약" Margin="203,348,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <ToggleButton x:Name="tgle_bf_05" Width="40" Height="30" BorderThickness="0" Content="취약" Margin="203,383,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <ToggleButton x:Name="tgle_bf_06" Width="40" Height="30" BorderThickness="0" Content="취약" Margin="203,418,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <ToggleButton x:Name="tgle_bf_07" Width="40" Height="30" BorderThickness="0" Content="취약" Margin="203,453,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <ToggleButton x:Name="tgle_af_01" Width="40" Height="30" BorderThickness="0" Content="취약" Margin="259,243,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <ToggleButton x:Name="tgle_af_03" Width="40" Height="30" BorderThickness="0" Content="취약" Margin="259,313,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <ToggleButton x:Name="tgle_af_04" Width="40" Height="30" BorderThickness="0" Content="취약" Margin="259,348,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <ToggleButton x:Name="tgle_af_05" Width="40" Height="30" BorderThickness="0" Content="취약" Margin="259,383,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <ToggleButton x:Name="tgle_af_06" Width="40" Height="30" BorderThickness="0" Content="취약" Margin="259,418,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <ToggleButton x:Name="tgle_af_07" Width="40" Height="30" BorderThickness="0" Content="취약" Margin="259,453,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <Label Content="점검 전" HorizontalAlignment="Left" Margin="193,212,0,0" VerticalAlignment="Top" FontSize="12" FontWeight="Bold" FontStyle="Italic"/>
        <Label Content="점검 후" HorizontalAlignment="Left" Margin="259,212,0,0" VerticalAlignment="Top" FontSize="12" FontWeight="Bold" FontStyle="Italic"/>
        <TextBox x:Name="tb_ClipData" HorizontalAlignment="Left" Height="145" Margin="358,40,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="319" AcceptsReturn="True" BorderThickness="0" VerticalScrollBarVisibility="Auto"/>
        <Label Content="↓아래에 복사한 클립보드를 붙여넣기 하세요" HorizontalAlignment="Left" Margin="358,10,0,0" VerticalAlignment="Top" FontSize="14"/>
        <Button x:Name="btn_Start" Content="1. 점검 시작" HorizontalAlignment="Left" Margin="358,215,0,0" VerticalAlignment="Top" Width="234" Background="#FFB0EFF5" Height="55" BorderThickness="0" FontSize="16"/>
        <Button x:Name="btn_ClipWrite" Content="2. 클립보드 입력" HorizontalAlignment="Left" Margin="358,288,0,0" VerticalAlignment="Top" Width="234" Background="#FFB0EFF5" Height="55" BorderThickness="0" FontSize="16" IsEnabled="False"/>
        <Button x:Name="btn_End" Content="3. 점검 종료" HorizontalAlignment="Left" Margin="358,358,0,0" VerticalAlignment="Top" Width="234" Background="#FFB0EFF5" Height="55" BorderThickness="0" FontSize="16" IsEnabled="False"/>
        <Button x:Name="btn_Exit" Content="X" HorizontalAlignment="Left" Margin="358,453,0,0" VerticalAlignment="Top" Width="32" Height="30" Background="#FFDC4D4D" Foreground="White" FontSize="24" FontWeight="Bold" BorderThickness="0" Padding="0"/>
        <Label Content="* 구글플레이 프로텍트 인증" HorizontalAlignment="Left" Margin="10,278,0,0" VerticalAlignment="Top" Height="30" VerticalContentAlignment="Center"/>
        <ToggleButton x:Name="tgle_bf_02" Width="40" Height="30" BorderThickness="0" Content="취약" Margin="203,278,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top"/>
        <ToggleButton x:Name="tgle_af_02" Width="40" Height="30" BorderThickness="0" Content="취약" Margin="259,278,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top"/>
    </Grid>
</Window>
'@

[xml]$gui_xmal = $gui_xmal -replace 'mc:Ignorable="d"','' -replace "x:N",'N' -replace '^<Win.*', '<Window'

$xamlreader = (New-Object System.Xml.XmlNodeReader $gui_xmal)
$GUI = [Windows.Markup.XamlReader]::Load($xamlreader)

$gui_xmal.SelectNodes("//*[@Name]") | ForEach-Object { Set-Variable -Name ($_.Name) -Value $GUI.FindName($_.Name) }


# ------------------------------------------------------------------------

# NOW WE GET START

# ------------------------------------------------------------------------

$btn_Start.Add_Click({ gostart })

function gostart {
    $tb_StartTime.Text = (Get-Date).ToString()
    $tb_OSver.Text = $tb_ClipData.Text
    getData
}

function getData {

    $tb_OSVer.Text = ($tb_ClipData | Select-String -Pattern '(?<=안드로이드 버전\s).+').Matches.Value
    
}



$GUI.ShowDialog() | out-null