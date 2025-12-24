using GameStore.Cms.Extensions;
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
    public class SubscriberStateStorage: HubStorage<SubscriberModel>
    {
        readonly CurrentUserService CurrentUserService;
        readonly Radzen.NotificationService RadzenNotificationService;
        readonly HubConnectionProvider HubConnectionProvider;
        readonly SubscriberService subscriberService;

        public SubscriberStateStorage(CurrentUserService currentUserService, HubConnectionProvider hubConnectionProvider, SubscriberService subscriberService, Radzen.NotificationService radzenNotificationService)
        {
            HubConnectionProvider = hubConnectionProvider;
            CurrentUserService = currentUserService;

            currentUserService.OnLogout += Clear;
            this.subscriberService = subscriberService;
            RadzenNotificationService = radzenNotificationService;
        }


        public async override Task ConnectAsync()
        {
            try
            {
                await LoadAsync();

                if (Hub is not null)
                    return;

                var User = await CurrentUserService.GetCurrentUserAsync();
                Hub = HubConnectionProvider.GetOrCreateConnection<ReceiveSubscriberStateModel>("presence",
                                                                         new Dictionary<string, Action<ReceiveSubscriberStateModel>>
                                                                         {
                                                                                     {
                                                                                         "UserState",
                                                                                         (message)=> {

                                                                                             ChangeState(new SubscriberModel
                                                                                             {
                                                                                                 Id = Guid.Parse(message.UserId),
                                                                                                 IsConnected=message.IsConnected
                                                                                             });
                                                                                         }
                                                                                     }
                                                                         }, new() { { ClaimTypes.FluxifyApiKey, User.Claims[ClaimTypes.FluxifyApiKey] } });

                if (Hub is not null)
                {
                    await Hub.StartAsync();
                    await SnapShotAsync();
                }
            }
            catch (Exception ex)
            {
                RadzenNotificationService.Error("Hub Bağlantı Hatası", ex.Message);
            }
            
        }
        public void ChangeState(SubscriberModel receiveSubscriber)
        {
            SubscriberModel? subscriber = _items.FirstOrDefault(x => x.Key == receiveSubscriber.Id.ToString());

            if (subscriber != null)
                subscriber.IsConnected = receiveSubscriber.IsConnected;
            else
                _items.Add(receiveSubscriber);

            StateChanged();
        }

        public async Task SnapShotAsync()
        {
            var onlineSubscribers = await Hub?.InvokeAsync<List<ReceiveSubscriberStateModel>>("GetOnlineSubscribers");

            _items.Where(x => onlineSubscribers.Any(y => y.UserId == x.Key)).ToList()
                        .ForEach(x => x.IsConnected = true);

            StateChanged();
        }

        public async Task LoadAsync()
        {
            var result = await subscriberService.GetListAsync();

            if (result.Success)
                _items = result?.Data ?? new();


            StateChanged();
        }
    }
}
