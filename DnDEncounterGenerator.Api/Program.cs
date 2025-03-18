using DnDEncounterGenerator.Api.Data;
using DnDEncounterGenerator.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MonsterDB");
var connectionStringEncounter = builder.Configuration.GetConnectionString("EncounterDB");

// Add services to the container.

builder.Services.AddDbContextFactory<MonsterDataContext>(options => options.UseSqlite(connectionString));
builder.Services.AddDbContextFactory<MonsterDataContext>(options => options.UseSqlite(connectionStringEncounter));

builder.Services.AddScoped<IMonsterRepository, MonsterRepository>();
builder.Services.AddScoped<IEncounterRepository, EncounterRepository>();

builder.Services.AddCors(options => { options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//This builder is how you can fix the circular reference issue that occurs with many to many relationships
builder.Services.AddMvc().AddJsonOptions(
    o =>
    {
        o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("Open");

app.UseAuthorization();

app.MapControllers();

app.Run();
