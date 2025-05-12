var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    name: "Profil",
    areaName: "Profil",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "Pendaftaran",
    areaName: "Pendaftaran",
    pattern: "Pendaftaran/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "DashboardAdmin",
    areaName: "DashboardAdmin",
    pattern: "Dashboard/Admin/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "DashboardGuru",
    areaName: "DashboardGuru",
    pattern: "Dashboard/Guru/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "DashboardSiswa",
    areaName: "DashboardSiswa",
    pattern: "Dashboard/Siswa/{controller=Home}/{action=Index}/{id?}");

app.Run();
