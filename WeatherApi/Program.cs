using WeatherApi.Infrastructure.Extensions;
using WeatherApi.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddHttpClient<WeatherService>();
builder.Services.AddDependendyInjectionContainer();
builder.Services.AddMemoryCache();

builder.Services.AddLogging(options =>
    {
        options.AddConsole();
        options.AddDebug();
    });

builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();