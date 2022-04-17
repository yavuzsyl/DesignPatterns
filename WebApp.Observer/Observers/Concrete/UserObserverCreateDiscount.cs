using WebApp.Observer.Models;
using WebApp.Observer.Subject;

namespace WebApp.Observer.Observers
{
    public class UserObserverCreateDiscount : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly UserObserverSubject _userObserverSubject;

        public UserObserverCreateDiscount(
           IServiceProvider serviceProvider,
           UserObserverSubject userObserverSubject)
        {
            _serviceProvider = serviceProvider;
            _userObserverSubject = userObserverSubject;
            userObserverSubject.RegisterObserver(this);
        }

        //app user yerine sadece kullanılacak bilgileri get edilmei 
        public void UserCreated(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverCreateDiscount>>();

            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppIdentiyDbContext>();

            context.Discounts.Add(new Discount { Rate = 10, UserId = appUser.Id });
            context.SaveChanges();
            logger.LogInformation($"Discount created! for {appUser.UserName}");
        }
    }
}
