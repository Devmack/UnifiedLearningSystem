using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using UnifiedLearningSystem.Application.Shared.Identity;
using UnifiedLearningSystem.Application.Shared.Media;
using UnifiedLearningSystem.Application.Shared.Pagination;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Application.Shared.Security;
using UnifiedLearningSystem.Application.Shared.Statistics;
using UnifiedLearningSystem.Infrastructure.Identity;
using UnifiedLearningSystem.Infrastructure.Media;
using UnifiedLearningSystem.Infrastructure.Pagination;
using UnifiedLearningSystem.Infrastructure.Persistence;
using UnifiedLearningSystem.Infrastructure.Security;
using UnifiedLearningSystem.Infrastructure.Stats;

namespace UnifiedLearningSystem.Infrastructure
{
    public static class DependencyInjectorContainer
    {
        public static void InjectInfrastructureLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<UnifiedLearningSystemContext>(options =>
                options.UseSqlServer(config["ApplicationDatabases:LearningSystem"]));

            services.AddDbContext<ApplicationUserContext>(options =>
                options.UseSqlServer(config["ApplicationDatabases:Identity"]));

            var builder = services.AddIdentityCore<IdentityUser<Guid>>(options =>
                                       options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationUserContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = config["Token:Issuer"],
                    ValidAudience = config["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"]))
                };

                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";
                        return c.Response.WriteAsync(c.Exception.ToString());
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject("401 Not authorized");
                        return context.Response.WriteAsync(result);
                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = 403;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject("403 Not authorized");
                        return context.Response.WriteAsync(result);
                    },
                };
            });

            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddSignInManager<SignInManager<IdentityUser<Guid>>>();

            services.AddScoped<ILearningTaskRepository, LearningTaskRepository>();
            services.AddScoped<ITaskUserRepository,TaskUserRepository>();
            services.AddScoped<ILearningLessonRepository,LearningLessonRepository>();

            services.AddScoped<IUnitOfWork, LearningUnitOfWork>();

            services.AddTransient<IIdentityService, LearningIdentityService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IPaginationService, PaginationService>();
            services.AddTransient<IMediaService, MediaService>();
            services.AddTransient<IStatsService, StatsService>();
        }
    }
}