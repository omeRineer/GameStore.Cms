using GameStore.Cms.Models.Domain.Meta;
using GameStore.Cms.Models.Meta.Notification;
using GameStore.Cms.Services.Internal;
using GameStore.Cms.Services.Meta;

namespace GameStore.Cms.Storages
{
    public class NotificationStorage
    {
        readonly NotificationService NotificationService;

        public NotificationStorage(NotificationService notificationService, CurrentUserService currentUserService)
        {
            NotificationService = notificationService;

            currentUserService.OnLogout += Clear;
        }

        List<NotificationModel> _notifications { get; set; } = new();
        public IReadOnlyList<NotificationModel> Notifications
            => _notifications.AsReadOnly();
        public event Action? OnChanged;

        public void Add(NotificationModel notification)
        {
            _notifications.Add(notification);

            OnChanged?.Invoke();
        }

        public async Task LoadAsync()
        {
            var result = await NotificationService.GetListAsync<GetNotificationsModel>();

            if (result.Success)
                _notifications = result?.Data?.Notifications ?? new();

            OnChanged?.Invoke();
        }

        public void ForceChanged()
        {
            OnChanged?.Invoke();
        }

        public void Clear()
        {
            _notifications.Clear();

            OnChanged?.Invoke();
        }
    }
}
