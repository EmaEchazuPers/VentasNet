using Microsoft.EntityFrameworkCore;
using VentasNet.Entity.Data;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();

builder.Services.AddDbContext<VentasNetContext>(options=>options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

//Se agrega para las conexiones de cada entidad

builder.Services.AddScoped<IClienteRepo, ClienteRepo>();
builder.Services.AddScoped<IProveedorRepo, ProveedorRepo>();
builder.Services.AddScoped<IVentaRepo, VentaRepo>();
builder.Services.AddScoped<IUsuarioRepo, UsuarioRepo>();

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
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();
