namespace Backend_MiSalud.Clases.Notification
{
    public interface INotificationObserver
    {
       void Update(string subject, string body);
    }
}
