using Laul.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly.GetName().Name;

builder.Services.AddIndentityServices(builder.Configuration, assembly);

var app = builder.Build();

app.UseIdentityServer();
app.Run();
