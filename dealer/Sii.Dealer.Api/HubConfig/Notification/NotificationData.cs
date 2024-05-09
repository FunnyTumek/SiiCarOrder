namespace Sii.Dealer.Api.HubConfig.Notification
{
    public class NotificationData
    {
        public int Type { get; set; }
        public string? Message { get; set; }
    }

    public enum NotificationType
    {
        Success,
        Warning,
        Error
    }

}
