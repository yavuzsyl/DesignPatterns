using WebApp.Observer.Models;
using WebApp.Observer.Observers;

namespace WebApp.Observer.Subject
{
    public interface IUserObserverSubject
    {
        void RegisterObserver(IUserObserver observer);
        void RemoveObserver(IUserObserver observer);
        void NotifyObservers(AppUser appUser);
    }
}
