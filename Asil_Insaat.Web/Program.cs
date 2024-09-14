using Asil_Insaat.Data.Context;
using Asil_Insaat.Data.Uzantilar;
using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Service.Describers;
using Asil_Insaat.Service.Extensions;
using Microsoft.AspNetCore.Identity;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);
builder.Services.LoadDataLayerExtension(builder.Configuration);
builder.Services.LoadServiceLayerExtension();   // geri gelecek
builder.Services.AddSession();
// Add services to the container.
builder.Services.AddControllersWithViews(opt =>
{
})
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        PositionClass = ToastPositions.TopRight,
        TimeOut = 5000,
        ProgressBar = true,
        TitleClass = "Baþarýlý."
    })
    .AddRazorRuntimeCompilation();



builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;

})
   .AddRoleManager<RoleManager<AppRole>>()
    .AddErrorDescriber<CustomIdentityErrorDescriber>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Giris");
    config.LogoutPath = new PathString("/Admin/Auth/Logout"); 
    config.Cookie = new CookieBuilder
    {
        Name = "Asil_Insaat",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest,  //diðer projlerde always seçilmeli
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(45); //oturum açýk kalacak süre beliler
    config.AccessDeniedPath = new PathString("/Admin/Auth/HataliGiris");


});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{Controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
});

app.Run();
