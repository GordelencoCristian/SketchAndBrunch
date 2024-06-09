using BackOffice.Shared.Models;
using MediatR;

namespace BackOffice.Client.Services
{
    public interface ILocationService
    {
        Task<List<LocationModel>> GetLocations();
        Task<Unit> AddEditLocation(LocationModel locationModel);
        Task<Unit> DeleteLocation(int locationId);
    }
}
