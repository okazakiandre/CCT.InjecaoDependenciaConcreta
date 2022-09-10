var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/clientes/{cpf}", (long cpf) =>
{
    return new Cliente(cpf, "Jose da Silva", 12345010);
})
.WithName("ObterClientePorCpf");

app.Run();

internal record Cliente(
    long NumeroCpf, 
    string Nome,
    int CepEntrega
);
