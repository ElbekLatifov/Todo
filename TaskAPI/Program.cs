using FluentValidation;
using TaskAPI.Context;
using TaskAPI.Models;
using TaskAPI.Services;
using TaskAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IValidator<TaskModel>, TaskValidator>(); 

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(options=>
{
    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});

app.Run();
