using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using SIAkademik.Domain.Authentication;
using SIAkademik.Infrastructure;
using SIAkademik.Web.Areas;
using SIAkademik.Web.Authentication;
using SIAkademik.Web.Services.Toastr;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.AccessDeniedPath = new PathString("/Home/AccessDenied");
        options.LoginPath = new PathString("/Home/Login");
        options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        options.SlidingExpiration = true;
    });

builder.Services.AddScoped<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ISignInManager, SignInManager>();
builder.Services.AddScoped<IToastrNotificationService, ToastrNotificationService>();

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

app.MapAreaControllerRoute(
    name: AreaNames.Profil,
    areaName: AreaNames.Profil,
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: AreaNames.Pendaftaran,
    areaName: AreaNames.Pendaftaran,
    pattern: "Pendaftaran/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: AreaNames.DashboardAdmin,
    areaName: AreaNames.DashboardAdmin,
    pattern: "Dashboard/Admin/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: AreaNames.DashboardGuru,
    areaName: AreaNames.DashboardGuru,
    pattern: "Dashboard/Guru/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: AreaNames.DashboardSiswa,
    areaName: AreaNames.DashboardSiswa,
    pattern: "Dashboard/Siswa/{controller=Home}/{action=Index}/{id?}");

app.Run();
