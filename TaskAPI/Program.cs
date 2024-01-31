using FluentValidation;
using TaskAPI.Context;
using TaskAPI.Models;
using TaskAPI.Services;
using TaskAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

//var logger = new LoggerConfiguration()
//    .WriteTo.File("log.txt", LogEventLevel.Information, rollingInterval: RollingInterval.Day)
//    .CreateLogger();

//builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddProvider(new LoggerProvider());
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
