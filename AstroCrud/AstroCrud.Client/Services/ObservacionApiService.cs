using System.Net.Http.Json;
using AstroCrud.Client.Models;

namespace AstroCrud.Client.Services
{
    public class ObservacionApiService
    {
        private readonly HttpClient _httpClient;

        public ObservacionApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ObservacionAstronomicaDto>> GetAllAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<List<ObservacionAstronomicaDto>>("api/observaciones");
            return data ?? new List<ObservacionAstronomicaDto>();
        }

        public async Task<ObservacionAstronomicaDto?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ObservacionAstronomicaDto>($"api/observaciones/{id}");
        }

        public async Task<bool> CreateAsync(ObservacionAstronomicaDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/observaciones", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, ObservacionAstronomicaDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/observaciones/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/observaciones/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}