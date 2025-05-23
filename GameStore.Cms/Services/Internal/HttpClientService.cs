using Blazored.LocalStorage;
using GameStore.Cms.Extensions;
using GameStore.Cms.Models.Identity;
using Radzen;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace GameStore.Cms.Services.Internal
{
    public class HttpClientService
    {
        readonly CurrentUserService CurrentUserService;
        readonly ISyncLocalStorageService LocalStorageService;
        readonly HttpClient _httpClient;
        readonly NotificationService NotificationService;

        public HttpClientService(HttpClient httpClient, ISyncLocalStorageService localStorageService, CurrentUserService currentUserService, NotificationService notificationService)
        {
            _httpClient = httpClient;
            LocalStorageService = localStorageService;
            CurrentUserService = currentUserService;
            NotificationService = notificationService;


            SetHttpClientDefaultParameters("Bearer");
        }

        public async Task<TModel> GetAsync<TModel>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                await Notify(response);

            return await response.Content.ReadFromJsonAsync<TModel>();
        }

        public async Task<TModel> PostAsync<TModel>(string url, object data)
        {
            var response = await _httpClient.PostAsJsonAsync(url, data);

            if (!response.IsSuccessStatusCode)
                await Notify(response);

            return await response.Content.ReadFromJsonAsync<TModel>();
        }

        public async Task<TModel> DeleteAsync<TModel>(string url)
        {
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                await Notify(response);

            return await response.Content.ReadFromJsonAsync<TModel>();
        }

        async Task Notify(HttpResponseMessage response)
        {
            var message = await response.Content.ReadAsStringAsync();

            NotificationService.Error($"{(int)response.StatusCode} {response.StatusCode.ToString()}", message);

        }
        void SetHttpClientDefaultParameters(string scheme)
        {
            var token = LocalStorageService.GetItem<string>("AUTH_TOKEN");

            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, token);
        }
    }
}
