using Microsoft.AspNetCore.SignalR.Client;

namespace GameStore.Cms.Providers
{
    public class HubConnectionProvider
    {
        Dictionary<string, HubConnection> Connections { get; } = new();
        public HubConnection CreateConnection<TMessage>(string path,
                                                        Dictionary<string, Action<TMessage>> events,
                                                        string token = null,
                                                        Func<Exception?, Task?> onStop = null)
        {
            var hubConnection = new HubConnectionBuilder()
            .WithUrl($"{CmsConfiguration.APIOptions.Meta.BaseUrl}{path}", opt =>
            {
                if (!string.IsNullOrEmpty(token))
                    opt.AccessTokenProvider = async () => await Task.FromResult(token);
            })
            .WithAutomaticReconnect()
            .Build();

            #region Events
            foreach (var method in events)
                hubConnection.On<TMessage>(method.Key, method.Value);

            if (onStop != null)
                hubConnection.Closed += onStop;

            hubConnection.Closed += (exception) =>
            {
                if (Connections.ContainsKey(path))
                    Connections.Remove(path);

                return Task.CompletedTask;
            };
            #endregion

            Connections[path] = hubConnection;

            return hubConnection;
        }

        public HubConnection GetConnection(string path)
            => Connections[path];

    }
}
