using AnimalsApi.DataBase;
using AnimalsApi.Services;
using AnimalsApi.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IAnimalTypeREP, AnimalTypeREP>();
builder.Services.AddScoped<IAbilityREP, AbilityREP>();
builder.Services.AddScoped<IAnimalREP, AnimalREP>();
builder.Services.AddScoped<IAnimalAbilityREP, AnimalAbilityREP>();

DBMySQLUtils.host = builder.Configuration["MYSQL_DBHOST"] ?? builder.Configuration.GetConnectionString("MYSQL_DBHOST");
DBMySQLUtils.port = builder.Configuration["MYSQL_DBPORT"] ?? builder.Configuration.GetConnectionString("MYSQL_DBPORT");
DBMySQLUtils.password = builder.Configuration["MYSQL_PASSWORD"] ?? builder.Configuration.GetConnectionString("MYSQL_PASSWORD");
DBMySQLUtils.userid = builder.Configuration["MYSQL_USER"] ?? builder.Configuration.GetConnectionString("MYSQL_USER");
DBMySQLUtils.database = builder.Configuration["MYSQL_DATABASE"] ?? builder.Configuration.GetConnectionString("MYSQL_DATABASE");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config => {
    config.EnableAnnotations();
});

var app = builder.Build();

// Prepare database
DataBaseConf.PrepareDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
