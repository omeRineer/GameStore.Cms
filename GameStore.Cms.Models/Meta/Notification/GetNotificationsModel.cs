using GameStore.Cms.Models.Domain.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Cms.Models.Meta.Notification
{
    public class GetNotificationsModel
    {
        public List<NotificationModel>? Notifications { get; set; }
    }
}
