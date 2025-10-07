using PracticaProgramada1BBL.Mapeos;
using PracticaProgramada1BBL.Servicios;
using PracticaProgramada1DAL.Repositorios;
using PracticaProgramada1DAL.Entidades;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IClientesRepositorio, ClientesRepositorio>();
builder.Services.AddSingleton<IClientesServicio, ClienteServicio>(); //Mala practics

builder.Services.AddAutoMapper(cfg => { }, typeof(MapeoClase));

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

app.MapControllerRoute(
    name: "Clientes",
    pattern: "{controller=Cliente}/{action=Index}/{id?}");

app.Run();
