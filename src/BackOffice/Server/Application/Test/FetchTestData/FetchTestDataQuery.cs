using BackOffice.Shared;
using MediatR;

namespace BackOffice.Server.Application.Test.FetchTestData
{
    public class FetchTestDataQuery : IRequest<IEnumerable<WeatherForecast>>
    {
    }
}
