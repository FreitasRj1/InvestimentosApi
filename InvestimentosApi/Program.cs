using InvestimentosBusiness;
using InvestimentosData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona Controllers
builder.Services.AddControllers();

// Configura Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Investimentos API",
        Version = "v1",
        Description = "API de investimentos com integração pública de CEP e consultas LINQ."
    });
});

// Injeta o Service
builder.Services.AddScoped<InvestimentoService>();

// Configuração do banco Oracle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// HTTP Client para chamadas externas (API de CEP)
builder.Services.AddHttpClient();

var app = builder.Build();

// Middleware do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Investimentos API v1");
    });
}

app.UseAuthorization();

// Endpoint raiz
app.MapGet("/", () => "🚀 API de Investimentos rodando com Swagger e API de CEP integrada!");

app.MapControllers();

await app.RunAsync();
