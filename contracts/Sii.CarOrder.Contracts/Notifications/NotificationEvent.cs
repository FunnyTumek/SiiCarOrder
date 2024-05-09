using Sii.CarOrder.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sii.CarOrder.Contracts.Notifications
{
    public class NotificationEvent 
    {
        public NotificationType Type { get; set; }
        public string Message { get; set; }

        public NotificationEvent(NotificationType type, string message)
        {
            Type = type;
            Message = message;
        }
    }
}
