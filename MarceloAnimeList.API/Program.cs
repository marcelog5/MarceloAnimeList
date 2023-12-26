using MarceloAnimeList.API;
using MarceloAnimeList.Infra._4._1_Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
       .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddConfiguration(builder.Configuration);

builder.Services.ConfigureJWT();

builder.Services.ConfigureAuthorization();

builder.Services.ConfigureMediator();

builder.Services.ConfigureMapper();

builder.Services.ConfigureHttpClient();

builder.Services.ConfigureDataBase(builder.Configuration);

builder.Services.ConfigureServices();

var app = builder.Build();

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
