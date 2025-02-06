
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using _36_webapp_MVC.ViewModels;
using System.Threading.Tasks;

namespace SupermercatoWebApp.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    // Pagina di Login
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return RedirectToRoleDashboard(roles);
            }
        }

        ModelState.AddModelError("", "Email o password errati.");
        return View(model);
    }

    // Pagina di Registrazione
    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = new IdentityUser { UserName = model.Email, Email = model.Email, EmailConfirmed = true };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, model.Role); // Assegna il ruolo selezionato
            await _signInManager.SignInAsync(user, isPersistent: false);

            return RedirectToRoleDashboard(new[] { model.Role });
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View(model);
    }

    // Logout
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // Metodo per reindirizzare alla dashboard in base al ruolo
    private IActionResult RedirectToRoleDashboard(IList<string> roles)
    {
        if (roles.Contains("Admin")) return RedirectToAction("Dashboard", "Admin");
        if (roles.Contains("Cassiere")) return RedirectToAction("Dashboard", "Cassiere");
        if (roles.Contains("Magazziniere")) return RedirectToAction("Dashboard", "Magazziniere");

        return RedirectToAction("Index", "Home"); // Default se il ruolo non è riconosciuto
    }
}