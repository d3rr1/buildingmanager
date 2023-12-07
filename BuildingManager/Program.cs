using Data;
using Domain.Interfaces;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBuildingAgent, Building1Agent>();
builder.Services.AddSingleton<IBuildingAgent, BuildingRedzichtAgent>();
builder.Services.AddSingleton<IBuildingAgent, BuildingGreenveldAgent>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddSingleton<IGasContractAgent, GasContractAgent>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
