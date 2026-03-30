//vinicius silva bueno
//ANNA JULIA GAGELINSKI
//LUANA VICENTE DOS SANTOS


using Microsoft.EntityFrameworkCore;
using TarefasApi;

var builder = WebApplication.CreateBuilder(args);

var conn = builder
            .Configuration
            .GetConnectionString("ConnPadrao");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(conn, ServerVersion.AutoDetect(conn)));

//Criando politica de Cors
builder.Services.AddCors(options =>
{
    //.WhithOrigins("https://localhost:300")
    options.AddPolicy("Liberado", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers(); //Habilitar controllers MVC
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); // Comentado para desenvolvimento - desabilita redirecionamento HTTPS
app.UseCors("Liberado"); //Aplica a politica de Cors
app.UseAuthorization();
app.MapControllers(); // Publica as rotas dos controlelrs

app.Run();

