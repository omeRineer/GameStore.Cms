using Blazored.LocalStorage;
using GameStore.Cms.Extensions;
using Radzen;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace GameStore.Cms.Services.Internal
{
    public class HttpClientService
    {
        readonly Event @event;
        readonly CurrentUserService CurrentUserService;
        readonly ISyncLocalStorageService LocalStorageService;
        readonly NotificationService RadzenNotificationService;

        public HttpClientService(ISyncLocalStorageService localStorageService, CurrentUserService currentUserService, NotificationService radzenNotificationService, Event @event)
        {
            LocalStorageService = localStorageService;
            CurrentUserService = currentUserService;
            RadzenNotificationService = radzenNotificationService;

            this.@event = @event;
        }

        public async Task<TModel> GetAsync<TModel>(string url, Dictionary<string, object> headers = null)
        {
            var client = CreateClient(headers);

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                await Notify(response);

            return await response.Content.ReadFromJsonAsync<TModel>();
        }

        public async Task<TModel> PostAsync<TModel>(string url, object data, Dictionary<string, object> headers = null)
        {
            var client = CreateClient(headers);

            var response = await client.PostAsJsonAsync(url, data);

            if (!response.IsSuccessStatusCode)
                await Notify(response);

            return await response.Content.ReadFromJsonAsync<TModel>();
        }

        public async Task<TModel> DeleteAsync<TModel>(string url, Dictionary<string, object> headers = null)
        {
            var client = CreateClient(headers);

            var response = await client.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                await Notify(response);

            return await response.Content.ReadFromJsonAsync<TModel>();
        }

        async Task Notify(HttpResponseMessage response)
        {
            var message = await response.Content.ReadAsStringAsync();

            RadzenNotificationService.Error($"{(int)response.StatusCode} {response.StatusCode.ToString()}", message);

        }

        HttpClient CreateClient(Dictionary<string, object> headers = null)
        {
            var client = new HttpClient();

            var token = LocalStorageService.GetItem<string>("AUTH_TOKEN");

            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            if (headers != null && headers.Count > 0)
                foreach (var header in headers)
                    client.DefaultRequestHeaders.Add(header.Key, header.Value.ToString());

            return client;
        }
    }
}
