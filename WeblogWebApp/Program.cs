using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeblogWebApp.DataLayer;
using WeblogWebApp.ServiceLayer.Interfaces;
using WeblogWebApp.ServiceLayer.Interfaces.Post;
using WeblogWebApp.ServiceLayer.Interfaces.PostCategory;
using WeblogWebApp.ServiceLayer.Interfaces.PostMedia;
using WeblogWebApp.ServiceLayer.Interfaces.PostTag;
using WeblogWebApp.ServiceLayer.Interfaces.Role;
using WeblogWebApp.ServiceLayer.Interfaces.User;
using WeblogWebApp.ServiceLayer.Services.Post;
using WeblogWebApp.ServiceLayer.Services.PostCategory;
using WeblogWebApp.ServiceLayer.Services.PostMedia;
using WeblogWebApp.ServiceLayer.Services.PostTag;
using WeblogWebApp.ServiceLayer.Services.Role;
using WeblogWebApp.ServiceLayer.Services.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. ???? ??????
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(@"Data Source=MOHAMAD;Initial Catalog=WeblogWebApp_DB;Integrated Security=true;MultipleActiveResultSets=true");
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Account/Login/";
        option.LogoutPath = "/Account/Logout";
        option.ExpireTimeSpan = TimeSpan.FromDays(5);
    });


builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostCategoryService, PostCategoryService>();
builder.Services.AddScoped<IPostMediaService, PostMediaService>();
builder.Services.AddScoped<IPostTagService, PostTagService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
