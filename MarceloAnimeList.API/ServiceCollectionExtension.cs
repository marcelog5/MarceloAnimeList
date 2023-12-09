using AutoMapper;
using MarceloAnimeList.Domain.Command.UserAnimeComponents.Command;
using MarceloAnimeList.Domain.Command.UserAnimeComponents.Query;
using MarceloAnimeList.Domain.Command.UserComponents;
using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Data.Model;
using MarceloAnimeList.Domain.Data.Repository;
using MarceloAnimeList.Domain.Service;
using MarceloAnimeList.Domain.Util;
using MarceloAnimeList.Infra._4._1_Data;
using MarceloAnimeList.Infra._4._1_Data.Repository;
using MarceloAnimeList.Service.Command.UserAnimeComponents.Request;
using MarceloAnimeList.Service.Command.UserComponents.Request;
using MarceloAnimeList.Service.Service;
using MarceloAnimeList.Service.Service.HttpService;
using MarceloAnimeList.Service.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

                    cfg.CreateMap<LoginRequest, LoginCommand>();

                    cfg.CreateMap<CreateUserAnimeRequest, CreateUserAnimeCommand>();

                    cfg.CreateMap<GetUserAnimeRequest, GetUserAnimeQuery>();
                    cfg.CreateMap<UserAnime, GetUserAnimeQueryResponse>();

                    cfg.CreateMap<UserAnime, CreateUserAnimeCommandResponse>();
                    cfg.CreateMap<MyAnimeListModelData, Anime>()
                    .ForMember(d => d.Title, o => o.MapFrom(s => s.title))
                    .ForMember(d => d.ReleaseDate, o => o.MapFrom(s => s.aired.from))
                    .ForMember(d => d.EpisodeCount, o => o.MapFrom(s => s.episodes))
                    .ForMember(d => d.Type, o => o.Ignore())
                    .ForMember(d => d.Status, o => o.Ignore())
                    .ForMember(d => d.Season, o => o.Ignore());

                    cfg.CreateMap<UserAnime, UserAnimeResponse>()
                    .ForPath(d => d.Title, o => o.MapFrom(s => s.Anime.Title));
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

        public static void ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repository
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAnimeRepository, AnimeRepository>();
            services.AddTransient<IUserAnimeRepository, UserAnimeRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUserUtil, UserUtil>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserAnimeService, UserAnimeService>();
        }

        public static void ConfigureJWT(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyHere123456789012345678901234567890")),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

        }

        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("MALAuthPolicy", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    // Add other requirements as needed
                });
            });
        }
    }
}
