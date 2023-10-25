﻿using AutoMapper;
using MarceloAnimeList.Domain.Command.UserAnimeComponents.Command;
using MarceloAnimeList.Domain.Command.UserAnimeComponents.Query;
using MarceloAnimeList.Domain.Command.UserComponents;
using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Data.Repository;
using MarceloAnimeList.Infra._4._1_Data.Repository;
using MarceloAnimeList.Infra._4._1_Data;
using MarceloAnimeList.Service.Command.UserAnimeComponents.Request;
using MarceloAnimeList.Service.Command.UserComponents.Request;
using MarceloAnimeList.Service.Service.HttpService;
using Microsoft.EntityFrameworkCore;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Service.Service;

namespace MarceloAnimeList.API
{
    public static class ServiceCollectionExtension
    {
        private static IConfiguration _configuration;

        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            _configuration = configuration;
            return services;
        }

        public static void ConfigureMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateUserRequest).Assembly);
            });

        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(sp =>
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CreateUserRequest, CreateUserCommand>();
                    cfg.CreateMap<CreateUserCommand, User>();
                    cfg.CreateMap<User, CreateUserCommandResponse>();

                    cfg.CreateMap<CreateUserAnimeRequest, CreateUserAnimeCommand>();

                    cfg.CreateMap<GetUserAnimeRequest, GetUserAnimeQuery>();
                    cfg.CreateMap<UserAnime, GetUserAnimeQueryResponse>();
                });

                return configuration.CreateMapper();
            });
        }

        public static void ConfigureHttpClient(this IServiceCollection services)
        {
            HttpClient httpClient = new MALHttpClientFactory().CreateClient("");
            MALHttpClient malHttpClient = new MALHttpClient(httpClient);
            services.AddSingleton(malHttpClient);
        }

        public static void ConfigureDataBase(this IServiceCollection services)
        {
            // Read the connection string from appsettings.json
            IConfiguration DBConfig = _configuration.GetSection("ConnectionStrings");
            // Configure DbContext using the connection string
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(DBConfig.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Scoped);

            // Repository
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserAnimeRepository, UserAnimeRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserAnimeService, UserAnimeService>();
        }
    }
}