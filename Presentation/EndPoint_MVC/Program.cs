using Application.Configuration;
using Infrastructure.Configuration;
using Serilog;


var builder = WebApplication.CreateBuilder(args);


#region Services
builder.Services.AddControllersWithViews();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServcies();

#endregion

#region Serilog

var config = builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();


Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();


builder.Host.UseSerilog();



#endregion


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
