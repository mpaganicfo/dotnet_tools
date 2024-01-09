using Presentation.Boostrap;
using Microsoft.Extensions.DependencyInjection;
using Application.Bootstrap;
using Infrastructure.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureAppConfiguration(builder =>
{
    builder.AddYamlFile("appsettings.Development.yml", optional: false);
});
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.HttpClientsConfiguration(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
