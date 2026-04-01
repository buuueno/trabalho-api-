//vinicius silva bueno
//ANNA JULIA GAGELINSKI
//LUANA VICENTE DOS SANTOS


using Microsoft.EntityFrameworkCore;
using ProdutosApi;
using ProdutosApi.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TestDb"));

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

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilterAttribute>()); //Habilitar controllers MVC
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

