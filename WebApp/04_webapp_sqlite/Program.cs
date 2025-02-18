var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build(); //* default 

//------ //* Con Globalization
// var cultureInfo = new CultureInfo("it-IT");
// CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
// CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// var app = builder.Build();  
// app.UseRequestLocalization(new RequestLocalizationOptions
// {
//     DefaultRequestCulture = new RequestCulture("it-IT"),
//     SupportedCultures = new List<CultureInfo> { cultureInfo },
//     SupportedUICultures = new List<CultureInfo> { cultureInfo }
// });

// Posizioniamo qui l'inizializzione del database
DatabaseInitializer.InitializeDatabase();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
