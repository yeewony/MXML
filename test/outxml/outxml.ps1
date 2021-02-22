﻿$Carrier = "K444wT"

$xml= @"
<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<MOBILE-Check>
	<START_TIME>2021-02-10 19:22:24</START_TIME>
	<END_TIME>2021-02-10 19:22:56</END_TIME>
	<ANDROID_VERSION>11</ANDROID_VERSION>
	<MODEL_VERSION>갤럭시13</MODEL_VERSION>
	<MANUFACTURER>삼성</MANUFACTURER>
	<CARRIER>$Carrier</CARRIER>
	<MO-01>
		<NAME>스마트폰 잠금 설정 여부</NAME>
		<RESULT>Y</RESULT>
	</MO-01>
	<MO-02>
		<NAME>구글 Play 프로텍트 인증 상태</NAME>
		<RESULT>Y</RESULT>
	</MO-02>
	<MO-03>
		<NAME>최신 보안 업데이트 여부</NAME>
		<RESULT>Y</RESULT>
	</MO-03>
	<MO-04>
		<NAME>개발자 옵션 활성화 여부</NAME>
		<RESULT>Y</RESULT>
	</MO-04>
	<MO-05>
		<NAME>앱 권한 관리 점검</NAME>
		<RESULT>Y</RESULT>
	</MO-05>
	<MO-06>
		<NAME>구글 2단계 인증 활성화 여부</NAME>
		<RESULT>Y</RESULT>
	</MO-06>
	<MO-07>
		<NAME>백신 설치 여부</NAME>
		<RESULT>Y</RESULT>
	</MO-07>
</MOBILE-Check>

"@

#$path = "$PSScriptRoot\$Carrier.xml"

$xml.Save("$PSScriptRoot\$Carrier.xml")
#$xml.OuterXml | Out-File -FilePath $PSScriptRoot"\"$Carrier".xml"