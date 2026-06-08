using Mardre.Endpoints;

var builder = WebApplication.CreateBuilder(args);


// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("http://master-fron-1mgghl-77be1c-2-25-185-88.sslip.io")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usar a política de CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.AddCategoriaEndpoints();
app.AddMateriaPrimaEndpoints();
app.AddProcessamentoEndpoints();

app.Run();
