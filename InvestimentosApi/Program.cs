using InvestimentosBusiness;
using InvestimentosData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configuração do OpenAPI nativo
builder.Services.AddOpenApi();

// Injeta a Service
builder.Services.AddScoped<InvestimentoService>();

// Configuração do banco (Oracle)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// 🔧 Desabilitar redirecionamento HTTPS por enquanto
// app.UseHttpsRedirection();

app.UseAuthorization();

// 🔧 Rota de teste para confirmar se a API sobe
app.MapGet("/", () => "API está rodando!");

app.MapControllers();

await app.RunAsync();
