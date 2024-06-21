using BackOffice.Shared.Models;
using MediatR;
using SharedData.Models;

namespace BackOffice.Client.Services
{
    public interface ILocationService
    {
        Task<List<LocationModel>> GetLocations();
        Task<Unit> AddEditLocation(LocationModel locationModel);
        Task<Unit> DeleteLocation(int locationId);
    }
}
