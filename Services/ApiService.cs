using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using SmartWMS.Models;

namespace SmartWMS.Services;

public class ApiService
{
    private readonly HttpClient _client;
    private readonly string _baseUrl;

    public ApiService(string baseUrl = "https://shelfsim-api-190183336439.asia-northeast3.run.app")
    {
        _baseUrl = baseUrl;
        _client = new HttpClient { BaseAddress = new Uri(baseUrl) };
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    // Materials - List
    public async Task<List<MaterialResponseDto>> GetMaterialsAsync(string? search = null, string? type = null)
    {
        var url = "/api/materials";
        var queryParams = new List<string>();

        if (!string.IsNullOrEmpty(search))
            queryParams.Add($"search={Uri.EscapeDataString(search)}");

        if (!string.IsNullOrEmpty(type))
            queryParams.Add($"type={Uri.EscapeDataString(type)}");

        if (queryParams.Count > 0)
            url += "?" + string.Join("&", queryParams);

        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<MaterialResponseDto>>() ?? new List<MaterialResponseDto>();
    }

    // Materials - Get by ID
    public async Task<MaterialResponseDto?> GetMaterialAsync(string id)
    {
        var response = await _client.GetAsync($"/api/materials/{id}");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            return null;

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<MaterialResponseDto>();
    }

    // Materials - Create
    public async Task<MaterialResponseDto?> CreateMaterialAsync(MaterialResponseDto material)
    {
        var response = await _client.PostAsJsonAsync("/api/materials", material);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<MaterialResponseDto>();
    }

    // Materials - Update
    public async Task<MaterialResponseDto?> UpdateMaterialAsync(string id, MaterialResponseDto material)
    {
        var response = await _client.PutAsJsonAsync($"/api/materials/{id}", material);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<MaterialResponseDto>();
    }

    // Materials - Delete
    public async Task<bool> DeleteMaterialAsync(string id)
    {
        var response = await _client.DeleteAsync($"/api/materials/{id}");
        return response.IsSuccessStatusCode;
    }
}