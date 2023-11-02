#nullable disable
using Laul.Identity;
using Laul.Identity.Data;

var seed = args.Contains("/seed");
if(seed)
{
    args = args.Except(new[] { "/seed" }).ToArray();
}

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly.GetName().Name;

if (seed)
{
    SeedData.EnsureSeedData(builder.Configuration.GetConnectionString("DefaultConnection"));
}

builder.Services.AddIndentityServices(builder.Configuration, assembly);
builder.Services.AddControllersWithViews(); 

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();
