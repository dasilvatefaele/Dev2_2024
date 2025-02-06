# Web App MVC

> Creazione archetipo
```bash
dotnet new mvc --framework 8.0.12
or 
dotnet new mvc -n SupermercatoWebApp  --framework net8.0
```

> Dipendenze: Identity, Entity Framework Core e SQLite:

```bash
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
```

Aggiungo il dbcontext:

```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SupermercatoWeb.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
```

Aggiungere la stringa di connessione in appsettings.json:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=identity.db"
}
```

Aggiungere le direttive di utilizzo Identity DbContext e Servizi aggiuntivi:

```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupermercatoWeb.Data;
using SupermercatoWeb.Managers;
using SupermercatoWeb.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configura il DbContext per Identity (ad es. con SQLite)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=identity.db";
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

// Configura Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>() // Usa IdentityUser e IdentityRole
    .AddEntityFrameworkStores<ApplicationDbContext>() // Usa il DbContext per Identity
    .AddDefaultTokenProviders(); // Aggiunge il supporto ai token per la conferma dell'account

// Registra i servizi MVC
builder.Services.AddControllersWithViews();

// Registra i servizi di manager e repository
builder.Services.AddScoped<ProdottoRepository>();
builder.Services.AddScoped<ProdottoManager>();

// (Eventuali altre registrazioni per altri manager/repository)
// builder.Services.AddScoped<AcquistoManager>();
// builder.Services.AddScoped<AcquistoRepository>();
// ...

var app = builder.Build();

// Esegui il seeding dei dati
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedData.InitializeAsync(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); // Reindirizza le richieste HTTP a HTTPS
app.UseStaticFiles(); // Abilita l'uso di file statici (es. immagini, CSS, ecc.)
app.UseRouting(); // Abilita il routing delle richieste HTTP

app.UseAuthentication(); // Abilita l'autenticazione
app.UseAuthorization(); // Abilita l'autorizzazione

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Esegue l'applicazione
```

#### Comando per eseguire istruzioni dotnet-ef
---

```bash
dotnet tool install --global dotnet-ef
```

```bash
dotnet ef migrations add IdentitySetup
dotnet ef database update
```

