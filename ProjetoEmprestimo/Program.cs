using ProjetoEmprestimo.GerenciaArquivos;
using ProjetoEmprestimo.Repository;
using ProjetoEmprestimo.Repository.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

// Adicionando a interface como serviço
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

// Add Gerenciador Arquivo como Serviços
builder.Services.AddScoped<GerenciadorArquivo>();
builder.Services.AddScoped<ProjetoEmprestimo.Cookie.Cookie>();
builder.Services.AddScoped<ProjetoEmprestimo.CarrinhoCompra.CookieCarrinhoCompra>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
