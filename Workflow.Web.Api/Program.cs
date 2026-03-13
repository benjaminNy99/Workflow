using Microsoft.EntityFrameworkCore;
using Workflow.Infrastructure.Data;
using Workflow.Infrastructure.Data.Models;
using Workflow.Web.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("No hay una cadena de coneción a base de datos configurada.");

builder.Services.AddDbContext<Context>(options => options.UseSqlite(connectionString));

builder.Services.AddOpenApi();
builder.Services.AddRepository();
builder.Services.AddCodeRepository();
builder.Services.AddUseCases();

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.MapPriorityEndPoints();
app.MapTasksEndpoints();

app.Run();
