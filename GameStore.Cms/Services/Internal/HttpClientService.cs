using Blazored.LocalStorage;
using GameStore.Cms.Models.Identity;
using System.Net.Http.Json;

namespace GameStore.Cms.Services.Internal
{
    public class HttpClientService
    {
        readonly CurrentUserService CurrentUserService;
        readonly ILocalStorageService LocalStorageService;
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient, ILocalStorageService localStorageService, CurrentUserService currentUserService)
        {
            _httpClient = httpClient;
            LocalStorageService = localStorageService;
            CurrentUserService = currentUserService;
        }

        public async Task<TModel> GetAsync<TModel>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<TModel>();

            throw new HttpRequestException($"GET failed: {response.StatusCode}");
        }

        public async Task<TModel> PostAsync<TModel>(string url, object data)
        {
            var response = await _httpClient.PostAsJsonAsync(url, data);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<TModel>();

            throw new HttpRequestException($"POST failed: {response.StatusCode}");
        }

        public async Task<bool> DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}
