using Microsoft.EntityFrameworkCore;  
using Microsoft.EntityFrameworkCore.SqlServer; 
using MiniCore_MR.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ComisionesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ComisionesContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Comisiones}/{action=Index}/{id?}");

app.Run();
