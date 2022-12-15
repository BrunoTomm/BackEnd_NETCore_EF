using BackEnd_NETCore.Application.AutoMapper;
using BackEnd_NETCore.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Template.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

NativeInjector.RegistrarServicos(builder.Services);
builder.Services.AddDbContext<TemplateContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("BackEnd_NETCore")).EnableSensitiveDataLogging());
builder.Services.AddAutoMapper(typeof(AutoMapperSetup));


builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
