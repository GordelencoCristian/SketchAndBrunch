using BackOffice.Shared.Models;
using MediatR;

namespace BackOffice.Client.Services
{
    public interface IRequestService
    {
        Task<int> AddEditRequest(RequestModel requestModel);
        Task<List<RequestModel>> GetRequests();
        Task<Unit> DeleteRequest(int? requestId);
    }
}
