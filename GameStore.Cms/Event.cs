using GameStore.Cms.Extensions;
using Radzen;

namespace GameStore.Cms
{
    public class Event
    {
        readonly NotificationService notificationService;

        public Event(NotificationService notificationService)
        {
            this.notificationService = notificationService;

            OnException += HandleException;
        }



        public Action<Exception> OnException;
        public Action<NotificationSeverity, string, string>? OnNotify;


        void HandleException(Exception exception)
            => notificationService.Error(exception.GetType().Name, exception.Message);
    }
}
