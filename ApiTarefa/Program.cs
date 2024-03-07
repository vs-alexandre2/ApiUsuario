using Microsoft.EntityFrameworkCore;
using ApiTarefa.ApiTarefa.Infrastructure.DataContexts;
using ApiTarefa.ApiTarefa.Infrastructure.Repositorys;
using ApiTarefa.ApiTarefa.Domain.Models;
using ApiTarefa.ApiTarefa.Domain.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITarefaRepository,TarefaRepository>();
builder.Services.AddTransient<IValidator<TarefaModel>, TarefaValidator>();
builder.Services.AddDbContext<TarefaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("TarefasApp", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("TarefasApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
