using Auth.Logger;
using Auth.Middlewares;
using BuisenessLogic;
using DataBaseLogic;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddExceptionLogger();
builder.Services.AddUserService();
builder.Services.AddUserRepository();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseSwagger();
app.UseSwaggerUI();
app.UseExceptionLogger();
app.MapControllers();


app.Run();
