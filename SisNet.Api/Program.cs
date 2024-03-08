using SisNet.Api.Configurations;
using SisNet.IoC;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;


services.AddControllers();
services.AddEndpointsApiExplorer();

// ***---manual service configuration---***.

// swagger
SwaggerSetup.AddSwaggerSetup(services);
// entity framework
EntityFrameworkSetup.AddEntityFrameworkSetup(services, configuration);
// cors
CorsSetup.AddCorsSetup(services);
// automapper
AutoMapperSetup.AddAutoMapperSetup(services);
// registros dos contratos.
DependencyInjection.Register(services);

// ***---using services---***.

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // setup para configuração do swagger
    SwaggerSetup.UseSwaggerSetup(app);
}

// setup para o Cors
CorsSetup.UseCorsSetup(app);

app.UseAuthorization();

app.MapControllers();

app.Run();
