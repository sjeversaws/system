using Microsoft.EntityFrameworkCore;
using SystemA_API;
using SystemA_API.Data;
using SystemA_API.Models;
using SystemA_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var engineeringSystem =
    Environment.GetEnvironmentVariable("EngineeringSystem") switch
    {
        "A" => C.EngineeringSystemA,
        "B" => C.EngineeringSystemB,
        "C" => C.EngineeringSystemC,
        "D" => C.EngineeringSystemD,
        "E" => C.EngineeringSystemE,
        _ => C.EngineeringSystemE
    };

builder.Services.AddSingleton<IEngineeringSystem>(engineeringSystem);
builder.Services.AddScoped<IMessagingService, MessagingService>();

var cstring = Environment.GetEnvironmentVariable("pgConnectionString");
if (cstring == null)
    throw new InvalidOperationException("pgConnectionString is null");

builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(cstring), ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
using (var dbContext = serviceScope.ServiceProvider.GetService<DataContext>())
{
    if (dbContext == null)
        throw new InvalidOperationException("dbContext is null");
    
    //dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();