using WebApp.Decorator.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Decorator.Repositories;
using WebApp.Decorator.Repositories.Decorators;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppIdentiyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AppIdentiyDbContext>();

builder.Services.AddHttpContextAccessor();

//1.yol scrutor ile
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IProductRepository, ProductRepository>()
    .Decorate<IProductRepository, ProductRepositoryCacheDecorator>()
    .Decorate<IProductRepository, ProductRepositoryLogDecorator>();

//2. yol
//builder.Services.AddScoped<IProductRepository>(sp => {

//    var cache = sp.GetRequiredService<IMemoryCache>();
//    var logger = sp.GetRequiredService<ILogger<ProductRepositoryLogDecorator>>();
//    var dbContext = sp.GetRequiredService<AppIdentiyDbContext>();
//    var repository = new ProductRepository(dbContext);

//    var cacheDecorator = new ProductRepositoryCacheDecorator(repository, cache);
//    var logDecorator = new ProductRepositoryLogDecorator(cacheDecorator, logger);
//    return logDecorator;

//});

//3. yol
//builder.Services.AddScoped<IProductRepository>(sp =>
//{
//    var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
//    var cache = sp.GetRequiredService<IMemoryCache>();
//    var logger = sp.GetRequiredService<ILogger<ProductRepositoryLogDecorator>>();
//    var dbContext = sp.GetRequiredService<AppIdentiyDbContext>();
//    var repository = new ProductRepository(dbContext);

//    var cacheDecorator = new ProductRepositoryCacheDecorator(repository, cache);

//    var isAdmin = httpContextAccessor.HttpContext.User.Identity.Name == "admin";
//    if (isAdmin)
//    {
//        var logDecorator = new ProductRepositoryLogDecorator(cacheDecorator, logger);
//        return logDecorator;
//    }

//    return cacheDecorator;

//});






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