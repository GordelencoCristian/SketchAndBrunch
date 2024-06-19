using FrontOffice.Server.DependencyInjection;
using Microsoft.AspNetCore.ResponseCompression;
using Persistance.DependecyInjection;
using SharedData.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppDbContext(builder.Configuration.GetConnectionString("Default"));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.ConfigureModuleApplication();
builder.Services.AddApplication();
builder.Services.ConfigureEmailSender(builder.Configuration.GetSection("Smtp"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();

}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

