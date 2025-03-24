using WebApiFuncionarios.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Chama o seu container de depend�ncias
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// Configura o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();
