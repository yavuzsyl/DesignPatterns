using WebApp.Observer.Models;
using WebApp.Observer.Observers;

namespace WebApp.Observer.Subject
{
    public class UserObserverSubject : IUserObserverSubject
    {
        private readonly List<IUserObserver> _observers;
        //private readonly AppUser _appUser;

        public UserObserverSubject()
        {
            _observers = new List<IUserObserver>();
        }

        //user geçmeden, kullanılacak alanları get edecek şekilde 
        public void NotifyObservers(AppUser appUser)
        {
            _observers.ForEach(x => x.UserCreated(appUser));
        }

        public void RegisterObserver(IUserObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IUserObserver observer)
        {
            _observers.Remove(observer);
        }
    }
}
