using Microsoft.AspNetCore.Authentication.Cookies;
using ProjetoLoja.Interfaces;
using ProjetoLoja.Repositorio;

var builder = WebApplication.CreateBuilder(args);
//injentando a dependência para validar a rota e dar permissão
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Usuario/Login";
        options.AccessDeniedPath = "/Usuario/AcessoNegado";
    });


//INJEÇÃO DE DEPENDÊNCIA
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();






// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//Muito importante para funcionar
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
