using BackOffice.Server.Application.Test.FetchTestData;
using BackOffice.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistance.Contexts;
using Persistance.Entities;

namespace BackOffice.Server.Controllers
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
        private readonly AppDbContext _appDbContext;
        private readonly ISender _sender;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext appDbContext, ISender sender)
        {
            _logger = logger;
            _appDbContext = appDbContext;
            _sender = sender;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _sender.Send(new FetchTestDataQuery());

            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}