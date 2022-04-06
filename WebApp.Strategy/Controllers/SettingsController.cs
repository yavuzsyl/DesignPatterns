using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Strategy.Models;

namespace WebApp.Strategy.Controllers;

public class SettingsController : Controller
{
    private readonly UserManager<AppUser> userManager;
    private readonly SignInManager<AppUser> signInManager;

    public SettingsController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
    }

    public IActionResult Index()
    {
        Setting setting = new();
        if (User.Claims.Where(x => x.Type == Setting.claimDatabaseType).FirstOrDefault() != null)
        {
            setting.DatabaseType = (DatabaseType)int.Parse(User.Claims.First(x => x.Type == Setting.claimDatabaseType).Value);
        }
        else
        {
            setting.DatabaseType = setting.GetDefaultDatabaseType();
        }
        return View(setting);
    }
    [HttpPost]
    public async Task<IActionResult> Change(int databaseType)
    {
        var user = await userManager.FindByNameAsync(User.Identity.Name);

        var claim = new Claim(Setting.claimDatabaseType, databaseType.ToString());
        
        var claims = await userManager.GetClaimsAsync(user);
        var existClaim = claims.FirstOrDefault(x => x.Type == Setting.claimDatabaseType);

        if (existClaim != null)
        {
            await userManager.ReplaceClaimAsync(user, existClaim, claim);
        }
        else
        {
            await userManager.AddClaimAsync(user, claim);
        }

        await signInManager.SignOutAsync();

        var authenticateResult = await HttpContext.AuthenticateAsync();

        await signInManager.SignInAsync(user, authenticateResult.Properties);
        return RedirectToAction(nameof(Index));
    }
}
