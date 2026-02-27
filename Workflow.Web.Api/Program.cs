using Microsoft.EntityFrameworkCore;
using Workflow.Infrastructure.Data;
using Workflow.Infrastructure.Data.Models;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("No hay una cadena de coneción a base de datos configurada.");

builder.Services.AddDbContext<Context>(options => options.UseSqlite(connectionString));

builder.Services.AddOpenApi();

builder.Services.AddRepository();
builder.Services.AddCodeRepository();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.Run();
