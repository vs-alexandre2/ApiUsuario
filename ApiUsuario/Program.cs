using Microsoft.EntityFrameworkCore;
using ApiUsuario.ApiUsuario.Infrastructure.DataContexts;
using ApiUsuario.ApiUsuario.Infrastructure.Repositorys;
using ApiUsuario.ApiUsuario.Domain.Models;
using ApiUsuario.ApiUsuario.Domain.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>();
builder.Services.AddTransient<IValidator<UsuarioModel>, UsuarioValidator>();
builder.Services.AddDbContext<UsuarioDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("UsuariosApp", builder =>
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
app.UseCors("UsuariosApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
