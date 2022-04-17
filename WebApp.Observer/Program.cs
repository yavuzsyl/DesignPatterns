using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Observer.Models;
using WebApp.Observer.Observers;
using WebApp.Observer.Subject;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSingleton<IUserObserverSubject>(sp => 
{
    UserObserverSubject userObserverSubject = new();
    //register ya böyle olabilir  
    //userObserverSubject.RegisterObserver(new UserObserverWriteToConsole(sp));
    //userObserverSubject.RegisterObserver(new UserObserverCreateDiscount(sp));
    //userObserverSubject.RegisterObserver(new UserObserverSendEmail(sp));
    //yada böyle
    new UserObserverWriteToConsole(sp, userObserverSubject);
    new UserObserverCreateDiscount(sp, userObserverSubject);
    new UserObserverSendEmail(sp, userObserverSubject);

    return userObserverSubject;
});

builder.Services.AddDbContext<AppIdentiyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AppIdentiyDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
DataSeed(app);
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



static IServiceScope DataSeed(WebApplication app)
{
    //data seed
    var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppIdentiyDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    //migration 
    dbContext.Database.Migrate(); // applies pending migrations to db will create the database if it does not already exist

    if (!userManager.Users.Any())
    {
        foreach (var item in Enumerable.Range(0, 5))
        {
            userManager.CreateAsync(new AppUser
            {
                UserName = $"DefaultUser{item}",
                Email = $"defaultuser{item}@gmail.com"
            },
            "Password12*").Wait();
        }
    }

    return scope;
}