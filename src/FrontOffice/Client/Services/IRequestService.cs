using FrontOffice.Shared.Models;

namespace FrontOffice.Client.Services
{
    public interface IRequestService
    {
        Task<int> AddRequest(RequestModel requestModel);
    }
}
