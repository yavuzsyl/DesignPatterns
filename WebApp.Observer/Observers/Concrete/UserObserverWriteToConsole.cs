using WebApp.Observer.Models;
using WebApp.Observer.Subject;

namespace WebApp.Observer.Observers
{
    public class UserObserverWriteToConsole : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserObserverSubject _userObserverSubject;
        private string UserName { get; set; }
        public UserObserverWriteToConsole(
            IServiceProvider serviceProvider, 
            UserObserverSubject userObserverSubject)
        {
            _serviceProvider = serviceProvider;
            _userObserverSubject = userObserverSubject;
            userObserverSubject.RegisterObserver(this);
        }

        public void UserCreated(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverWriteToConsole>>();
            //UserName = subject.GetUsername();
            logger.LogInformation($"User {appUser.UserName} was created");
        }
    }
}
