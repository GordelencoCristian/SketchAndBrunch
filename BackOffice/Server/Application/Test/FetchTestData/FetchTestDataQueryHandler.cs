using BackOffice.Shared;
using MediatR;
using Persistance.Contexts;

namespace BackOffice.Server.Application.Test.FetchTestData
{
    public class FetchTestDataQueryHandler : IRequestHandler<FetchTestDataQuery, IEnumerable<WeatherForecast>>
    {
        private readonly AppDbContext _appDbContext;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public FetchTestDataQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<WeatherForecast>> Handle(FetchTestDataQuery request, CancellationToken cancellationToken)
        {
            var user = _appDbContext.Users.FirstOrDefault();

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();

            return await Task.FromResult(result);
        }
    }
}
