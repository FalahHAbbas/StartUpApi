using System.Text.Json.Serialization;
using Mapster;
using Microsoft.EntityFrameworkCore;
using StartUpApi.Data;
using StartUpApi.Data.Repositories;
using StartUpApi.Models.Entities;
using StartUpApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddJsonOptions(options => {options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;});


builder.Services.AddDbContext<StartupContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Local")));
builder.Services.AddMapster();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDepartementService, DepartementService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDepartementRepository, DepartementRepository>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();