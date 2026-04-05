using Flunt.Notifications;

namespace Shared.Notifications;

public class NotificationContext : Notifiable<Notification>
{
    public bool IsInvalid => !IsValid;
}
