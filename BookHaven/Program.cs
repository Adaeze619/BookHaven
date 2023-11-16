using BookHaven.Infrastructure.DbContextFolder;
using BookHaven.Infrastructure.Interface;
using BookHaven.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UserDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AuthenticationConnectionString")));
builder.Services.AddDbContext<BookHavenDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BookHavenConnectionString")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
.AddEntityFrameworkStores<UserDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequireDigit = true;
	options.Password.RequireUppercase = true;
	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequireLowercase = true;
	options.Password.RequiredLength = 6;
	options.Password.RequiredUniqueChars = 1;
});

builder.Services.AddScoped<IBookHavenRepo, BookHavenRepo>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();

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
