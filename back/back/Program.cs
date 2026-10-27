using back.Logger;
using back.Middlewares;
using BusienessLayer;
using DataBaseLayer;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddExceptionLogger();
services.AddTaskRepository();
services.AddBusinessLayer();
services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseLogger();

app.Run();
