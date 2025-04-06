using System;

namespace Backend_MiSalud.Clases.Notification
{
    public class GlobalNotifier
    {
        private readonly List<INotificationObserver> _observers = new();
        private readonly string _subject;
        private readonly string _body;

        public GlobalNotifier(string subject, string body)
        {
            _subject = subject;
            _body = body;
        }

        public void AddObserver(INotificationObserver observer)
        {
            _observers.Add(observer);
        }

        public void NotifyAll()
        {
            foreach (INotificationObserver observer in _observers)
            {
                observer.Update(_subject, _body);
            }
        }
    }
}
