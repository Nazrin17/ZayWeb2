using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ZayWebSite.Context;
using ZayWebSite.Models;
using ZayWebSite.Services.Implementations;
using ZayWebSite.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddFluentValidation(op =>
{
    op.ImplicitlyValidateChildProperties = true;
    op.ImplicitlyValidateRootCollectionElements = true;
    op.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddDbContext<ZayDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddIdentity<AppUser, IdentityRole>(op =>
{
    op.Password.RequiredLength = 8;
    op.Lockout.AllowedForNewUsers = true;
    op.Lockout.MaxFailedAccessAttempts = 5;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<ZayDbContext>();   
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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Slider}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
