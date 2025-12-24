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
    public class NotificationStorage : HubStorage<NotificationModel>
    {
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

        public override async Task ConnectAsync()
        {
            await LoadAsync();

            if (Hub is not null)
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

            if (Hub is not null)
            {
                await Hub.StartAsync();
                StateChanged();
            }
            
        }

        public void Add(NotificationModel notification)
        {
            _items.Add(notification);

            StateChanged();
        }

        public async Task LoadAsync()
        {
            var result = await NotificationService.GetListAsync<GetNotificationsModel>();

            if (result.Success)
                _items = result?.Data?.Notifications ?? new();


            StateChanged();
        }
    }
}
