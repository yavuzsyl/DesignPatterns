using WebApp.Observer.Models;
using WebApp.Observer.Subject;

namespace WebApp.Observer.Observers
{
    public class UserObserverSendEmail : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserObserverSubject _userObserverSubject;

        public UserObserverSendEmail(
           IServiceProvider serviceProvider,
           IUserObserverSubject userObserverSubject)
        {
            _serviceProvider = serviceProvider;
            _userObserverSubject = userObserverSubject;
            userObserverSubject.RegisterObserver(this);
        }

        public void UserCreated(AppUser appUser)
        {
            var logger = _serviceProvider.GetService<ILogger<UserObserverSendEmail>>();
            logger.LogInformation("email sent to {0}", appUser.Email);
        }
    }

}
