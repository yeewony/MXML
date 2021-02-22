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
    <Window.Resources>
        <Style TargetType="ToggleButton">
            <Setter Property="Content" Value="취약"/>
            <Style.Triggers>
                <Trigger Property="IsChecked" Value="True">
                    <Setter Property="Content" Value="양호"/>
                </Trigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
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
        <ToggleButton x:Name="tgle_bf_01" Width="40" Height="30" BorderThickness="0"  Margin="203,243,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top" IsEnabled="False"/>
        <ToggleButton x:Name="tgle_bf_03" Width="40" Height="30" BorderThickness="0"  Margin="203,313,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top" IsEnabled="False"/>
        <ToggleButton x:Name="tgle_bf_04" Width="40" Height="30" BorderThickness="0"  Margin="203,348,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top" IsEnabled="False"/>
        <ToggleButton x:Name="tgle_bf_05" Width="40" Height="30" BorderThickness="0"  Margin="203,383,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top" IsEnabled="False"/>
        <ToggleButton x:Name="tgle_bf_06" Width="40" Height="30" BorderThickness="0"  Margin="203,418,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top" IsEnabled="False"/>
        <ToggleButton x:Name="tgle_bf_07" Width="40" Height="30" BorderThickness="0"  Margin="203,453,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top" IsEnabled="False"/>
        <ToggleButton x:Name="tgle_af_01" Width="40" Height="30" BorderThickness="0"  Margin="259,243,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top" IsEnabled="False"/>
        <ToggleButton x:Name="tgle_af_03" Width="40" Height="30" BorderThickness="0"  Margin="259,313,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top" IsEnabled="False"/>
        <ToggleButton x:Name="tgle_af_04" Width="40" Height="30" BorderThickness="0"  Margin="259,348,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top" IsEnabled="False"/>
        <ToggleButton x:Name="tgle_af_05" Width="40" Height="30" BorderThickness="0"  Margin="259,383,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top" IsEnabled="False"/>
        <ToggleButton x:Name="tgle_af_06" Width="40" Height="30" BorderThickness="0"  Margin="259,418,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top" IsEnabled="False"/>
        <ToggleButton x:Name="tgle_af_07" Width="40" Height="30" BorderThickness="0"  Margin="259,453,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top" IsEnabled="False"/>
        <Label Content="점검 전" HorizontalAlignment="Left" Margin="193,212,0,0" VerticalAlignment="Top" FontSize="12" FontWeight="Bold" FontStyle="Italic"/>
        <Label Content="점검 후" HorizontalAlignment="Left" Margin="259,212,0,0" VerticalAlignment="Top" FontSize="12" FontWeight="Bold" FontStyle="Italic"/>
        <TextBox x:Name="tb_ClipData" HorizontalAlignment="Left" Height="145" Margin="358,40,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="319" AcceptsReturn="True" BorderThickness="0" VerticalScrollBarVisibility="Auto"/>
        <Label Content="↓아래에 복사한 클립보드를 붙여넣기 하세요" HorizontalAlignment="Left" Margin="358,10,0,0" VerticalAlignment="Top" FontSize="14"/>
        <Button x:Name="btn_Start" Content="1. 점검 시작" HorizontalAlignment="Left" Margin="358,215,0,0" VerticalAlignment="Top" Width="234" Background="#FFB0EFF5" Height="55" BorderThickness="0" FontSize="16"/>
        <Button x:Name="btn_ClipWrite" Content="2. 클립보드 입력" HorizontalAlignment="Left" Margin="358,288,0,0" VerticalAlignment="Top" Width="234" Background="#FFB0EFF5" Height="55" BorderThickness="0" FontSize="16" IsEnabled="False"/>
        <Button x:Name="btn_End" Content="3. 점검 종료" HorizontalAlignment="Left" Margin="358,358,0,0" VerticalAlignment="Top" Width="234" Background="#FFB0EFF5" Height="55" BorderThickness="0" FontSize="16" IsEnabled="False"/>
        <Label Content="* 구글플레이 프로텍트 인증" HorizontalAlignment="Left" Margin="10,278,0,0" VerticalAlignment="Top" Height="30" VerticalContentAlignment="Center"/>
        <ToggleButton x:Name="tgle_bf_02" Width="40" Height="30" BorderThickness="0"  Margin="203,278,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top" IsEnabled="False"/>
        <ToggleButton x:Name="tgle_af_02" Width="40" Height="30" BorderThickness="0"  Margin="259,278,0,0" BorderBrush="White" Background="#FFAE3E3E" Foreground="Black" HorizontalAlignment="Left" VerticalAlignment="Top" IsEnabled="False"/>
        <Button x:Name="btn_SaveXML" Content="4. XML 생성" HorizontalAlignment="Left" Margin="358,428,0,0" VerticalAlignment="Top" Width="234" Background="#FFB0EFF5" Height="55" BorderThickness="0" FontSize="16" IsEnabled="False"/>
    </Grid>
</Window>
'@

[xml]$gui_xmal = $gui_xmal -replace 'mc:Ignorable="d"','' -replace "x:N",'N' -replace '^<Win.*', '<Window'

$xamlreader = (New-Object System.Xml.XmlNodeReader $gui_xmal)
$GUI = [Windows.Markup.XamlReader]::Load($xamlreader)

$gui_xmal.SelectNodes("//*[@Name]") | ForEach-Object { Set-Variable -Name ($_.Name) -Value $GUI.FindName($_.Name) }

$tgle_all = $tgle_af_01, $tgle_af_02, $tgle_af_03, $tgle_af_04, $tgle_af_05, $tgle_af_06, $tgle_af_07, $tgle_bf_01, $tgle_bf_02, $tgle_bf_03, $tgle_bf_04, $tgle_bf_05, $tgle_bf_06, $tgle_bf_07
$tgle_after = $tgle_af_01, $tgle_af_02, $tgle_af_03, $tgle_af_04, $tgle_af_05, $tgle_af_06, $tgle_af_07
$GLOBAL:tgle_before = $GLOBAL:tgle_bf_01, $GLOBAL:tgle_bf_02, $GLOBAL:tgle_bf_03, $GLOBAL:tgle_bf_04, $GLOBAL:tgle_bf_05, $GLOBAL:tgle_bf_06, $GLOBAL:tgle_bf_07

# ------------------------------------------------------------------------

# YOU WANT SOME XML?

# ------------------------------------------------------------------------

[xml]$MobileXML=@"
<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<MOBILE-Check>
	<START_TIME></START_TIME>
	<END_TIME></END_TIME>
	<ANDROID_VERSION></ANDROID_VERSION>
	<MODEL_VERSION></MODEL_VERSION>
	<MANUFACTURER></MANUFACTURER>
	<CARRIER></CARRIER>
	<MO-01>
		<NAME>스마트폰 잠금 설정 여부</NAME>
		<RESULT>$MO01</RESULT>
	</MO-01>
	<MO-02>
		<NAME>구글 Play 프로텍트 인증 상태</NAME>
		<RESULT>$MO02</RESULT>
	</MO-02>
	<MO-03>
		<NAME>최신 보안 업데이트 여부</NAME>
		<RESULT>$MO03</RESULT>
	</MO-03>
	<MO-04>
		<NAME>개발자 옵션 활성화 여부</NAME>
		<RESULT>$MO04</RESULT>
	</MO-04>
	<MO-05>
		<NAME>앱 권한 관리 점검</NAME>
		<RESULT>$MO05</RESULT>
	</MO-05>
	<MO-06>
		<NAME>구글 2단계 인증 활성화 여부</NAME>
		<RESULT>$MO06</RESULT>
	</MO-06>
	<MO-07>
		<NAME>백신 설치 여부</NAME>
		<RESULT>$MO07</RESULT>
	</MO-07>
</MOBILE-Check>

"@

$MO = $MO1, $MO2, $MO3, $MO4, $MO5, $MO6, $MO07


# ------------------------------------------------------------------------

# NOW GET WE START

# ------------------------------------------------------------------------

$btn_Start.Add_Click({ step1 })
$btn_ClipWrite.Add_Click({ step2 })
$btn_End.Add_Click({ step3 })
$btn_SaveXML.Add_Click({ step4 })

function step1 {
    $tb_StartTime.Text = (Get-Date).ToString()
    $btn_ClipWrite.IsEnabled = $true
    $btn_Start.IsEnabled = $false
    foreach ($tgle in $tgle_all){
        $tgle.IsEnabled= $true
    }
}

function step2 {
    parsing
    $btn_End.IsEnabled = $true
    $btn_ClipWrite.IsEnabled = $false
}

function step3 {
    $tb_EndTime.Text = (Get-Date).ToString()
    $btn_SaveXML.IsEnabled = $true
    $btn_End.IsEnabled = $false
}

function step4 {
    getBeforeTogleValue
    getAfterTogleValue
    SaveBeforeXML
    #압축하기
    #docx만들기?
    #
}

function parsing {
    $tb_OSVer.Text = ($tb_ClipData | Select-String -Pattern '(?<=안드로이드 버전\s).+').Matches.Value
    $tb_ModelName.Text = ($tb_ClipData | Select-String -Pattern '(?<=모델 번호\s).+').Matches.Value
    $tb_Manuf.Text = ($tb_ClipData | Select-String -Pattern '(?<=제조사\s).+').Matches.Value
    $tb_Carrier.Text = ($tb_ClipData | Select-String -Pattern '(?<=통신사\s).+').Matches.Value
}

function getBeforeTogleValue {
    foreach ($num in 0..($tgle_before.Count - 1))
{
    if($tgle_before[$num].IsChecked -eq $true)
    {
        $num += 1
        Set-Variable -Name "GLOBAL:tgle_bf_0$num" -Value "Y"

    }
    else {
        $num += 1
        Set-Variable -Name "GLOBAL:tgle_bf_0$num" -Value "N"
    }
}
}

function getAfterTogleValue {
    foreach ($num in 0..($tgle_after.Count - 1))
{
    if($tgle_after[$num].IsChecked -eq $true)
    {
        $num += 1
        Set-Variable -Name "GLOBAL:tgle_af_0$num" -Value "Y"

    }
    else {
        $num += 1
        Set-Variable -Name "GLOBAL:tgle_af_0$num" -Value "N"
    }
}
}

function SaveBeforeXML {
    #$tb_ModelName = $tb_ModelName.Text -replace '\s',''

    $MobileXML.'MOBILE-Check'.ANDROID_VERSION = $tb_OSVer.Text
    $MobileXML.'MOBILE-Check'.START_TIME = $tb_StartTime.Text
    $MobileXML.'MOBILE-Check'.END_TIME = $tb_EndTime.Text
    $MobileXML.'MOBILE-Check'.MANUFACTURER = $tb_Manuf.Text
    $MobileXML.'MOBILE-Check'.MODEL_VERSION = $tb_ModelName.Text
    $MobileXML.'MOBILE-Check'.CARRIER = $tb_Carrier.Text

    $MobileXML.'MOBILE-Check'.'MO-01'.RESULT = $tgle_bf_01
    $MobileXML.'MOBILE-Check'.'MO-02'.RESULT = $tgle_bf_02
    $MobileXML.'MOBILE-Check'.'MO-03'.RESULT = $tgle_bf_03
    $MobileXML.'MOBILE-Check'.'MO-04'.RESULT = $tgle_bf_04
    $MobileXML.'MOBILE-Check'.'MO-05'.RESULT = $tgle_bf_05
    $MobileXML.'MOBILE-Check'.'MO-06'.RESULT = $tgle_bf_06
    $MobileXML.'MOBILE-Check'.'MO-07'.RESULT = $tgle_bf_07

    $tb_ModelName = $tb_ModelName.Text -replace '\s',''
    $MobileXML.Save("$PSScriptRoot\MOBILE_"+$tb_ModelName+"_Result_Before.xml")
    #비포 xml
    #에프터 xml
}


$GUI.ShowDialog() | out-null