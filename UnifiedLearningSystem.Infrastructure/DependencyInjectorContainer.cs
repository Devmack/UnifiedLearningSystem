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
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Application.Shared.Security;
using UnifiedLearningSystem.Infrastructure.Identity;
using UnifiedLearningSystem.Infrastructure.Persistence;
using UnifiedLearningSystem.Infrastructure.Security;

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

            services.AddTransient<ILearningTaskRepository, LearningTaskRepository>();
            services.AddTransient<ITaskUserRepository,TaskUserRepository>();
            services.AddTransient<ILearningLessonRepository,LearningLessonRepository>();

            services.AddScoped<IUnitOfWork, LearningUnitOfWork>();

            services.AddTransient<IIdentityService, LearningIdentityService>();
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}