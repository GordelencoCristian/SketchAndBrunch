using BackOffice.Shared.Models;
using MediatR;

namespace BackOffice.Client.Services
{
    public interface IRequestService
    {
        Task<int> AddEditRequest(RequestModel requestModel);
        Task<int> ChangeStatus(ChangeStatusModel changeStatusModel);
        Task<List<RequestModel>> GetRequests();
        Task<Unit> DeleteRequest(int? requestId);
    }
}
