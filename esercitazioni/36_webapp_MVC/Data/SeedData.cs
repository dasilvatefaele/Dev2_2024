using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace SupermercatoWeb.Data;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;

        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

        // Definizione dei ruoli
        string[] roles = { "Admin", "Cassiere", "Magazziniere" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // Creazione utenti di esempio
        await CreateUserIfNotExists(userManager, "admin@supermercato.com", "Admin123!", "Admin");
        await CreateUserIfNotExists(userManager, "cassiere@supermercato.com", "Cassiere123!", "Cassiere");
        await CreateUserIfNotExists(userManager, "magazziniere@supermercato.com", "Magazziniere123!", "Magazziniere");
    }

    private static async Task CreateUserIfNotExists(UserManager<IdentityUser> userManager, string email, string password, string role)
    {
        if (await userManager.FindByEmailAsync(email) == null)
        {
            var user = new IdentityUser { UserName = email, Email = email, EmailConfirmed = true };
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}