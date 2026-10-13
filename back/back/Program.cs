using DataBaseLayer;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddTaskRepository();
services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
