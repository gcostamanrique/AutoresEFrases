using AplicacaoWeb01Infraestrutura.Log;
using AutoresEFrasesAplicacao.Servicos.Fabrica;
using AutoresEFrasesAplicacao.Servicos.Implementacao;
using AutoresEFrasesAplicacao.Servicos;
using AutoresEFrasesAplicacao.Validadores;
using AutoresEFrasesDominio.Interfaces.InterfacesAplicacao;
using AutoresEFrasesDominio.Interfaces.InterfacesInfraestrutura;
using AutoresEFrasesInfraestrutura.Dados;
using AutoresEFrasesInfraestrutura.Repositorios;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Enums;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configuração para a serealização dos objejetos vindos do banco de dados usando o Entity Framework, isso impede que consultas gerem ciclos de pesquisa.
builder.Services.AddControllersWithViews()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Adiciona o middleware de anti-forgery
builder.Services.AddAntiforgery(options =>
{
    // Configurações do anti-forgery (token)
    options.HeaderName = "X-XSRF-TOKEN"; // Nome do cabeçalho que será enviado
    options.Cookie.Name = "XSRF-TOKEN";  // Nome do cookie onde o token será armazenado
    options.Cookie.HttpOnly = false;     // Permitir que o token seja acessado via JavaScript
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Usar HTTPS se a requisição for segura
});

// Adiciona o middleware para validacao no APS.NET Core MVC do FluentValidation
builder.Services.AddFluentValidationAutoValidation(options =>
{
    options.ValidationStrategy = ValidationStrategy.All;
    options.OverrideDefaultResultFactoryWith<CustomResultFactory>();
});

// Conexão banco de dados
builder.Services.AddDbContext<ContextoBancoDados>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Conteiner DI
builder.Services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAutorRepositorio, AutorRepositorio>();
builder.Services.AddScoped<IFraseRepositorio, FraseRepositorio>();
builder.Services.AddScoped<ILogSistema, LogSistema>();

builder.Services.AddScoped<FabricaServico>();
builder.Services.AddScoped<IServico, Servico>();
builder.Services.AddScoped<IModificarAutor, GerarComplementoAutor>();
builder.Services.AddScoped<IModificarAutor, MarcarAutorComoAtivo>();
builder.Services.AddScoped<IModificarAutor, MarcarAutorComoInativo>();
builder.Services.AddScoped<IModificarIEnumerableAutor, MarcarAutorComoAtivo>();
builder.Services.AddScoped<IModificarIEnumerableAutor, MarcarAutorComoInativo>();
builder.Services.AddScoped<IModificarFrase, GerarComplementoFrase>();
builder.Services.AddScoped<IModificarFrase, MarcarFraseComoAtivo>();
builder.Services.AddScoped<IModificarFrase, MarcarFraseComoInativo>();
builder.Services.AddScoped<IModificarIEnumerableFrase, MarcarFraseComoAtivo>();
builder.Services.AddScoped<IModificarIEnumerableFrase, MarcarFraseComoInativo>();

// Definicao das regras para as classes do FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<POSTAutorDTOValidador>();
builder.Services.AddValidatorsFromAssemblyContaining<POSTFraseDTOValidador>();

var app = builder.Build();

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
    pattern: "{controller=Autor}/{action=Index}/{id?}");

app.Run();
