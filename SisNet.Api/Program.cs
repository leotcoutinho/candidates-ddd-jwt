using SisNet.Api.Configurations;
using SisNet.Application.MapperProfiles;
using SisNet.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ***---configurações manuais---***.

// swagger
builder.Services.AddSwaggerSetup();
// entity framework
builder.Services.AddEntityFrameworkSetup(builder.Configuration);
// cors
builder.Services.AddCorsSetup();
// automapper
builder.Services.AddAutoMapper(typeof(DtoToModelProfile), typeof(ModelToDTOProfile));

// registros dos contratos.
DependencyInjection.Register(builder.Services);

//***----------------------------***

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
