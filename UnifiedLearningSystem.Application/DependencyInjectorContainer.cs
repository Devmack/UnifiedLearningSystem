using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Application.DTOs.Lesson;
using UnifiedLearningSystem.Application.DTOs.TaskUser;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.Application
{
    public static class DependencyInjectorContainer
    {
        public static void InjectApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<ILearningCoreMapper<LearningTask, LearningTaskCreateDTO>, LearningCoreMapper>();
            services.AddScoped<ILearningCoreMapper<LearningTask, LearningTaskReadDTO>, LearningCoreReadMapper>();
            services.AddScoped<ILearningCoreMapper<TaskUserReadDTO, TaskUser>, LearningOwnerMapper>();
            services.AddScoped<ILearningCoreMapper<TaskUserCreateDTO, TaskUser>, LearningOwnerCreateMapper>();
            services.AddScoped<ILearningCoreMapper<LearningLessonReadDTO, LearningLesson>, LearningLessonMapper>();
            services.AddScoped<ILearningCoreMapper<LearningLessonCreateDTO, LearningLesson>, LearningLessonCreateMapper>();
            services.AddScoped<ILearningCoreMapper<AddTaskToLessonDTO, LearningLesson>, LearningLessonAddTasksUpdateMapper>();

            
        }
    }
}