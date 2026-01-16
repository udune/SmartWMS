WPF 클라이언트 연동 가이드
프로젝트: Smart WMS - WPF 메인 클라이언트
역할: 메인 제어 시스템 (자재 관리, 입출고, 환경 모니터링)
통신 방식: REST API (HTTP/JSON)
백엔드: ShelfSimAPI (.NET 9.0)

1. 서버 주소
환경URL개발
1. http://localhost:5109
1. 운영
1. https://shelfsim-api-xxxxx.run.app

2. API 엔드포인트
2.1 자재 관리 (Material)
기능
1. MethodEndpoint


1. 목록 조회
1. GET
1. /api/materials


1. 상세 조회
1. GET
1. /api/materials/{id}


1. 검색
1. GET
1. /api/materials?search=키워드타입 필터GET/api/materials?type=PR등록
1. POST
1. /api/materials


1. 수정
1. PUT
1. /api/materials/{id}


1. 삭제
1. DELETE
1. /api/materials/{id}


2.2 입출고
기능
1. MethodEndpoint
1. 입고
1. POST
1. /api/materials/inbound
1. 
1. 출고
1. POST
1. /api/materials/outbound


2.3 환경 설정
기능
MethodEndpoint
조회
GET
/api/environment/config

수정
PUT
/api/environment/config

2.4 재고/이력
기능
MethodEndpoint

셀별 재고
GET
/api/inventory/cells

특정 셀
GET
/api/inventory/cells/{cellCode}

자재별 재고
GET
/api/inventory/materials

작업 이력
GET
/api/jobs?runId={id}

3. 데이터 모델 (C# DTO)
3.1 Material 응답
csharppublic class MaterialResponseDto
{
    public string Id { get; set; }        // "1" (string)
    public string Name { get; set; }      // "KrF Photoresist A-Type"
    public string? Vendor { get; set; }   // "Dongjin Semichem"
    public string? LotId { get; set; }    // "LOT-2026-001"
    public string? Type { get; set; }     // "PR", "Thinner", "Developer"
    public int StockQty { get; set; }     // 100
    public DateTime? ExpiryDate { get; set; }
    public DateTime CreatedAt { get; set; }
}
3.2 입고 요청
csharppublic class InboundRequestDto
{
    public int MaterialId { get; set; }
    public string CellCode { get; set; }  // "A01" (대문자+숫자2자리)
    public int Qty { get; set; }
    public string? WorkerId { get; set; }
}
3.3 출고 요청 (환경 데이터 필수)
csharppublic class OutboundRequestDto
{
    public int MaterialId { get; set; }
    public string CellCode { get; set; }
    public int Qty { get; set; }
    public string? WorkerId { get; set; }
    public EnvironmentDataDto EnvData { get; set; }  // 필수!
}

public class EnvironmentDataDto
{
    public float CurrentTemp { get; set; }   // 현재 온도 (℃)
    public float CurrentHumid { get; set; }  // 현재 습도 (%)
    public bool IsLightLeak { get; set; }    // 빛 누출 여부
}
3.4 환경 설정
csharppublic class EnvironmentConfigDto
{
    public TemperatureConfig Temperature { get; set; }
    public HumidityConfig Humidity { get; set; }
    public LightControlConfig LightControl { get; set; }
}

public class TemperatureConfig
{
    public float Target { get; set; }     // 23.0
    public float Tolerance { get; set; }  // 2.0 (±2℃)
}

public class HumidityConfig
{
    public float Target { get; set; }     // 45.0
    public float Tolerance { get; set; }  // 5.0 (±5%)
}

public class LightControlConfig
{
    public bool AllowLight { get; set; }  // false (빛 차단)
}

4. 환경 인터락 규칙
4.1 기준값
항목목표허용 범위온도23℃21~25℃습도45%40~50%조도차단빛 감지 시 거부
4.2 출고 전 검증 (WPF 클라이언트)
csharppublic bool CanRequestOutbound(float temp, float humid, bool lightLeak)
{
    if (temp < 21 || temp > 25) return false;
    if (humid < 40 || humid > 50) return false;
    if (lightLeak) return false;
    return true;
}

서버에서도 이중 체크하므로, 클라이언트 검증은 UX 개선용


5. 에러 처리
5.1 HTTP 상태 코드
코드의미대응200성공정상 처리201생성됨리소스 생성400잘못된 요청입력값 확인404없음ID 확인406인터락경고 표시500서버 오류재시도
5.2 에러 응답 형식
json{
  "error": "ENV_INTERLOCK",
  "message": "온도 조건 불충족: 30.0℃ (허용: 21~25℃)",
  "jobId": 123
}
5.3 주요 에러 코드
코드설명UI 대응ENV_INTERLOCK환경 조건 불충족경고 팝업MATERIAL_NOT_FOUND자재 없음ID 확인 안내MATERIAL_EXPIRED유효기간 만료폐기 안내

6. 통신 코드 예제
6.1 ApiService 클래스
csharppublic class ApiService
{
    private readonly HttpClient _client;
    private readonly string _baseUrl;

    public ApiService(string baseUrl = "http://localhost:5109")
    {
        _baseUrl = baseUrl;
        _client = new HttpClient { BaseAddress = new Uri(baseUrl) };
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    // 자재 목록
    public async Task<List<MaterialResponseDto>> GetMaterialsAsync(string? search = null)
    {
        var url = "/api/materials";
        if (!string.IsNullOrEmpty(search))
            url += $"?search={Uri.EscapeDataString(search)}";

        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<MaterialResponseDto>>();
    }

    // 출고 요청
    public async Task<OutboundResult> RequestOutboundAsync(OutboundRequestDto request)
    {
        var response = await _client.PostAsJsonAsync("/api/materials/outbound", request);

        if (response.StatusCode == System.Net.HttpStatusCode.NotAcceptable)
        {
            var error = await response.Content.ReadFromJsonAsync<ErrorResponse>();
            return new OutboundResult
            {
                Success = false,
                ErrorCode = error.Error,
                Message = error.Message
            };
        }

        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<SuccessResponse>();
        return new OutboundResult
        {
            Success = true,
            JobId = result.JobId,
            Message = result.Message
        };
    }

    // 환경 설정 조회
    public async Task<EnvironmentConfigDto> GetEnvironmentConfigAsync()
    {
        var response = await _client.GetAsync("/api/environment/config");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<EnvironmentConfigDto>();
    }
}

6.2 출고 버튼 핸들러
csharpprivate async void OnOutboundClick(object sender, RoutedEventArgs e)
{
    var request = new OutboundRequestDto
    {
        MaterialId = SelectedMaterial.Id,
        CellCode = CellCodeTextBox.Text,
        Qty = int.Parse(QtyTextBox.Text),
        WorkerId = CurrentUser.Id,
        EnvData = new EnvironmentDataDto
        {
            CurrentTemp = _sensorService.GetTemperature(),
            CurrentHumid = _sensorService.GetHumidity(),
            IsLightLeak = _sensorService.IsLightDetected()
        }
    };

    var result = await _apiService.RequestOutboundAsync(request);

    if (!result.Success)
    {
        MessageBox.Show(
            result.Message,
            "출고 불가 - 환경 조건 미충족",
            MessageBoxButton.OK,
            MessageBoxImage.Warning);
        return;
    }

    MessageBox.Show($"출고 작업 등록 완료 (Job ID: {result.JobId})");
}

7. 구현 우선순위
Phase 1: 기본

자재 목록/검색 화면
자재 등록/수정/삭제

Phase 2: 핵심

입고 요청 화면
출고 요청 화면 (환경 데이터 포함)
인터락 에러 처리 UI

Phase 3: 모니터링

환경 모니터링 대시보드
환경 설정 관리 화면
작업 이력 조회

Phase 4: 연동

Unity 시뮬레이션 연동 (Job 상태 표시)

8. Unity 연동
8.1 역할 분담
기능WPFUnity자재 CRUD✅❌입출고 요청✅❌환경 모니터링✅❌창고 3D 시각화❌✅로봇 애니메이션❌✅
8.2 작업 흐름
[WPF] 출고 요청 (POST /api/materials/outbound)
    ↓
[API] 환경 체크 → Job 생성 (Action: OUT)
    ↓
[Unity] Job 폴링 (GET /api/jobs?runId=X)
    ↓
[Unity] 로봇 시뮬레이션 → 결과 업데이트
    ↓
[WPF] 완료 확인

9. MVVM 구조 권장
WpfClient/
├── Models/
│   ├── MaterialResponseDto.cs
│   ├── OutboundRequestDto.cs
│   └── EnvironmentConfigDto.cs
├── ViewModels/
│   ├── MaterialListViewModel.cs
│   ├── OutboundViewModel.cs
│   └── DashboardViewModel.cs
├── Views/
│   ├── MaterialListView.xaml
│   ├── OutboundView.xaml
│   └── DashboardView.xaml
├── Services/
│   ├── ApiService.cs
│   └── SensorService.cs
└── App.xaml

10. 테스트 시나리오
정상 출고
환경: 23℃, 45%, 빛 없음
예상: 200 OK
인터락 (온도)
환경: 30℃, 45%, 빛 없음
예상: 406 "온도 조건 불충족"
인터락 (습도)
환경: 23℃, 60%, 빛 없음
예상: 406 "습도 조건 불충족"
인터락 (빛)
환경: 23℃, 45%, 빛 감지
예상: 406 "빛 누출 감지"
유효기간 만료
자재 ExpiryDate: 2025-01-01 (과거)
예상: 406 "자재 유효기간 만료"