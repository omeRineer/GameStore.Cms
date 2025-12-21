using Microsoft.AspNetCore.SignalR.Client;

namespace GameStore.Cms.Storages
{
    public abstract class HubStorage<TModel>
    {
        public HubConnection? Hub { get; protected set; }
        public IReadOnlyList<TModel> Items
            => _items.AsReadOnly();
        public event Action? OnReceived;

        protected List<TModel> _items = new List<TModel>();

        public abstract Task ConnectAsync();
        public virtual async Task DisconnectAsync()
        {
            if (Hub is not null)
            {
                await Hub.StopAsync();
                Hub = null;
                Clear();
            }
        }

        public virtual void StateChanged()
            => OnReceived?.Invoke();

        public virtual void Clear()
        {
            _items.Clear();

            OnReceived?.Invoke();
        }
    }
}
