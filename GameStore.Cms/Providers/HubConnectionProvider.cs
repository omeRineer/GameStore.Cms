using Microsoft.AspNetCore.SignalR.Client;
using System.Web;

namespace GameStore.Cms.Providers
{
    public class HubConnectionProvider
    {
        Dictionary<string, HubConnection> Connections { get; } = new();
        public HubConnection? GetOrCreateConnection<TMessage>(string hub,
                                                        Dictionary<string, Action<TMessage>> events,
                                                        Dictionary<string, string> queryParams = null)
        {
            if (Connections.TryGetValue(hub, out var conn))
                return conn;

            var uri = GetUrl(hub, queryParams);

            var hubConnection = new HubConnectionBuilder()
            .WithUrl(uri)
            .WithAutomaticReconnect()
            .Build();

            #region Events
            foreach (var method in events)
                hubConnection.On<TMessage>(method.Key, method.Value);

            #endregion

            Connections[hub] = hubConnection;

            return hubConnection;
        }

        Uri GetUrl(string path, Dictionary<string, string>? queryParameters = null)
        {
            var urlBuilder = new UriBuilder($"{CmsConfiguration.FluxifyOptions.HubUrl}/{path}");
            var query = HttpUtility.ParseQueryString(urlBuilder.Query);

            if (queryParameters != null)
                foreach (var param in queryParameters)
                    query[param.Key] = param.Value;

            urlBuilder.Query = query.ToString();

            return urlBuilder.Uri;
        }

        public HubConnection? GetSingleOrDefault(string path)
            => Connections.SingleOrDefault(f => f.Key == path).Value;

        public HubConnection GetSingle(string path)
            => Connections[path];
    }
}
