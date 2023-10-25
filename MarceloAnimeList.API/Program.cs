using AutoMapper;
using MarceloAnimeList.Domain.Command.UserAnimeComponents;
using MarceloAnimeList.Domain.Command.UserComponents;
using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Data.Repository;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Infra._4._1_Data;
using MarceloAnimeList.Infra._4._1_Data.Repository;
using MarceloAnimeList.Service.Command.UserAnimeComponents.Request;
using MarceloAnimeList.Service.Command.UserComponents.Request;
using MarceloAnimeList.Service.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CreateUserRequest).Assembly);
});

// Mapp
builder.Services.AddSingleton<IMapper>(sp =>
{
    var configuration = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<CreateUserRequest, CreateUserCommand>();
        cfg.CreateMap<CreateUserCommand, User>();
        cfg.CreateMap<User, CreateUserCommandResponse>();

        cfg.CreateMap<GetUserAnimeRequest, GetUserAnimeQuery>();
        cfg.CreateMap<UserAnime, GetUserAnimeQueryResponse>();
    });

    return configuration.CreateMapper();
});

// Read the connection string from appsettings.json
IConfiguration DBConfig = builder.Configuration.GetSection("ConnectionStrings");
// Configure DbContext using the connection string
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(DBConfig.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Scoped);

// Repository
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserAnimeRepository, UserAnimeRepository>();

// Services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserAnimeService, UserAnimeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
