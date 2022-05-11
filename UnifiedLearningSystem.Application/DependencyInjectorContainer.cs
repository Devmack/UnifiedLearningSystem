using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application
{
    public static class DependencyInjectorContainer
    {
        public static void InjectApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ILearningCoreMapper<LearningTask, LearningTaskCreateDTO>, LearningCoreMapper>();
            services.AddScoped<ILearningCoreMapper<LearningTask, LearningTaskReadDTO>, LearningCoreReadMapper>();
        }
    }
}