var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllersWithViews(); //OJO: Agregar controladores y vistas - atte: david
builder.Services.AddDistributedMemoryCache(); // OJO: Agregar caché en memoria RAM (no persistente que significa que solo se guarda cuando la vara esta en ejecucion) distribuida - atte: david
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // OJO: Tiempo de espera de la sesión - atte: david
    options.Cookie.HttpOnly = true; // OJO: La cookie no es accesible desde JavaScript - atte: david
    options.Cookie.IsEssential = true;  // OJO: La cookie es esencial para la aplicación - atte: david
});

var app = builder.Build();

// Configurar el middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
