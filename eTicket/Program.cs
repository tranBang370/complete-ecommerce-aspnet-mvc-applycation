using eTickets.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add services to the container.
builder.Services.AddControllersWithViews();

//Thông thường, có file startup.cs
//để cấu hình DbContext configuration thì dùng 
//services.AddDBCOntext<AppDbContext>();
//nay không có thì gọi luôn thông

//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
//builder.Configuration.GetConnectionString("DefaultConnection")
//));

builder.Services.AddDbContext<AppDbContext>();

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
