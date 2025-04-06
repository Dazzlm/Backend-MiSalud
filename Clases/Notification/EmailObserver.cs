namespace Backend_MiSalud.Clases.Notification
{
    public class EmailObserver : INotificationObserver
    {
        private readonly string _email;
        private readonly ClsNotificaciones _clsNotificaciones;

        public EmailObserver(string email, ClsNotificaciones notificador)
        {
            _email = email;
            _clsNotificaciones = notificador;
        }

        public void Update(string subject, string body)
        {
            _clsNotificaciones.CreateNotification(_email, subject, body);
        }
    }
}


