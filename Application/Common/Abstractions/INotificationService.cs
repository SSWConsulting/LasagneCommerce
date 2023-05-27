namespace Application.Common.Abstractions;

public interface INotificationService
{
    Task SendEmailNotification(string emailAddress, string customerRef);
}
