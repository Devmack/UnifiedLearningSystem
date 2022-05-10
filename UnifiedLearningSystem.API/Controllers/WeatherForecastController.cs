using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnifiedLearningSystem.Application.DTOs.LearningTask;
using UnifiedLearningSystem.Application.Mappers;
using UnifiedLearningSystem.Domain.Entities;

namespace UnifiedLearningSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILearningCoreMapper<LearningTask, LearningTaskCreateDTO> mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILearningCoreMapper<LearningTask, LearningTaskCreateDTO> mapper)
        {
            _logger = logger;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var newLessonTask = new LearningTaskCreateDTO("test", "test");
            LearningTask t = mapper.ConvertFrom(newLessonTask);
            Console.WriteLine(t);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}