using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddRazorPages(options=>{
//    options.RootDirectory = "/Content";
//});

builder.Services.AddMemoryCache();
builder.Services.AddSession(options => {
    options.Cookie.Name = "MySessionCookie";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    //options.IdleTimeout = new TimeSpan(0, 30, 0);  
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//var connectionString = app.Configuration.GetConnectionString("DefaultConnection");
//var connectionString = app.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
