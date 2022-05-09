using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UnifiedLearningSystem.Application
{
    public static class DependencyInjectorContainer
    {
        public static void InjectApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}