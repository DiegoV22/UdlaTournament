using frontend.Services.Interfaces;
using frontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar los servicios en el contenedor de dependencias
builder.Services.AddScoped<IJugadoresService, JugadoresService>();
builder.Services.AddScoped<IEquiposService, EquiposService>();
builder.Services.AddScoped<ITorneosService, TorneosService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();


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

// Configurar las rutas para iniciar en Login/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
