using CCT.InjecaoDependenciaConcreta.Api.Application;
using CCT.InjecaoDependenciaConcreta.Api.Configurations;
using CCT.InjecaoDependenciaConcreta.Api.Infrastructure.ExternalServices;
using CCT.InjecaoDependenciaConcreta.Api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFluxoPedido, FluxoPedidoRefat>();
builder.Services.AddScoped<FluxoFrete>();
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<RegiaoRepository>();

var edp = builder.Configuration.GetRequiredSection("externalEndpoints");
var url = edp.GetValue<string>("clienteApi:url");
var cliApi = new ClienteApiClient(url);
builder.Services.AddSingleton(cliApi);

builder.Services.AddSingleton<IExternalEndpoints>(srv =>
    new ExternalEndpoints(srv.GetRequiredService<IConfiguration>())
);

builder.Services.AddHttpClient<IClienteApiClient, ClienteApiClientRefat>((srv, cli) =>
{
    var edps = srv.GetRequiredService<IExternalEndpoints>();
    var edp = edps.GetItem("clienteApi");
    cli.BaseAddress = new Uri(edp.Url);
    cli.Timeout = TimeSpan.FromMilliseconds(edp.Timeout);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

