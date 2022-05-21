using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Infrastructure.Persistence;

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

            services.AddIdentityCore<IdentityUser<Guid>>(options =>
                                       options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationUserContext>();

            services.AddTransient<ILearningTaskRepository, LearningTaskRepository>();
        }
    }
}