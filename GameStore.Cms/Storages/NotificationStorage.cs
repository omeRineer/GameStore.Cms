using GameStore.Cms.Models.Domain.Meta;
using GameStore.Cms.Models.Enums;
using GameStore.Cms.Models.Meta.Notification;
using GameStore.Cms.Models.SignalR;
using GameStore.Cms.Providers;
using GameStore.Cms.Services.Internal;
using GameStore.Cms.Services.Meta;
using Microsoft.AspNetCore.SignalR.Client;

namespace GameStore.Cms.Storages
{
    public class NotificationStorage
    {
        public HubConnection? Hub { get; private set; }
        readonly CurrentUserService CurrentUserService;
        readonly HubConnectionProvider HubConnectionProvider;
        readonly NotificationService NotificationService;

        public NotificationStorage(NotificationService notificationService, CurrentUserService currentUserService, HubConnectionProvider hubConnectionProvider)
        {
            NotificationService = notificationService;
            HubConnectionProvider = hubConnectionProvider;
            CurrentUserService = currentUserService;

            currentUserService.OnLogout += Clear;
            
        }
        List<NotificationModel> _notifications { get; set; } = new();
        public IReadOnlyList<NotificationModel> Notifications
            => _notifications.AsReadOnly();
        public event Action? OnReceived;


        public async Task ConnectAsync()
        {
            await LoadAsync();

            if(Hub is not null)
                return;

            var User = await CurrentUserService.GetCurrentUserAsync();
            Hub = HubConnectionProvider.GetOrCreateConnection<ReceiveNotificationModel>("notification",
                                                                     new Dictionary<string, Action<ReceiveNotificationModel>>
                                                                     {
                                                                                     {
                                                                                         "ReceiveNotification",
                                                                                         (message)=> {

                                                                                             Add(new NotificationModel
                                                                                             {
                                                                                                 Id = message.Id,
                                                                                                 Content=message.Content,
                                                                                                 ContentType = message.ContentType,
                                                                                                 Level = message.Level,
                                                                                                 Sender = message.Sender,
                                                                                                 Title = message.Title,
                                                                                                 IsRead = message.IsRead,
                                                                                                 CreateDate = message.CreateDate,
                                                                                                 Custom = message.Custom,
                                                                                                 Topics = message.Topics
                                                                                             });
                                                                                         }
                                                                                     }
                                                                     }, new() { { ClaimTypes.FluxifyApiKey, User.Claims[ClaimTypes.FluxifyApiKey] } });

            await Hub.StartAsync();
        }

        public async Task DisconnectAsync()
        {
            if (Hub is not null)
            {
                await Hub.StopAsync();
                Hub = null;
                Clear();
            }
        }
        public void Add(NotificationModel notification)
        {
            _notifications.Add(notification);

            OnReceived?.Invoke();
        }

        public async Task LoadAsync()
        {
            var result = await NotificationService.GetListAsync<GetNotificationsModel>();

            if (result.Success)
                _notifications = result?.Data?.Notifications ?? new();


            OnReceived?.Invoke();
        }

        public void ForceChanged()
        {
            OnReceived?.Invoke();
        }

        public void Clear()
        {
            _notifications.Clear();

            OnReceived?.Invoke();
        }
    }
}
