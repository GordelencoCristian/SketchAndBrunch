using BackOffice.Shared.Models;
using MediatR;

namespace BackOffice.Server.Application.Requests.GetRequests
{
    public class GetRequestsQuery : IRequest<List<RequestModel>>
    {
    }
}
