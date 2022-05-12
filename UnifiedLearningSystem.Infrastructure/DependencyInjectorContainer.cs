using Microsoft.Extensions.DependencyInjection;
using UnifiedLearningSystem.Application.Shared.Repository;
using UnifiedLearningSystem.Infrastructure.Persistence;

namespace UnifiedLearningSystem.Infrastructure
{
    public static class DependencyInjectorContainer
    {
        public static void InjectInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDbContext<UnifiedLearningSystemContext>();
            services.AddTransient<ILearningTaskRepository, LearningTaskRepository>();
        }
    }
}