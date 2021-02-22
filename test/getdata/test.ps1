# $raw = @'
# 전화번호	+821058770566
# 통신사	KT
# 모델 번호	SM-G977N
# 시리얼 번호	Not Available
# 네트워크 종류	MOBILE(LTE)
# IP	192.0.0.4
# 로밍	false
# 안드로이드 버전	11(RP1A.200720.012.G977NKSU4EUA4)
# OS 버전	4.14.113-20604714
# 프로세서	arm64-v8a
# 메모리 사용량	Total: 7.65GB, Free: 2.43GB
# 내부 저장소	Total: 246GB, Free: 128GB
# SD 카드 저장소	N/A
# 해상도	Width : 1440, Height : 3040
# 언어	ko
# IMEI(디바이스 ID)	Not Available
# 배터리	73%
# 제조사	samsung(Knox : 33)(OneUI : 3.0)
# 앱 버전	v10.20.10.27.1
# '@

# #$raw

# $test1 = ($raw | Select-String -Pattern '(?<=통신사\s).+').Matches.Value
# #'(?<=Firmware Version:\s+)[\d.]+'

# $test1

# $todo = $todo1, $todo2, $todo3, $todo4

# $todo1 = $true
# $todo2 = $false
# $todo3 = $false
# $todo4 = $true

# foreach ($i in $todo){
#     if($i -eq $true){
        
#     }
#     else {
#         $i = "N"
#     }
# }
