using BackOffice.Shared.Models;
using MediatR;
using SharedData.Models;

namespace BackOffice.Server.Application.Locations.AddEditLocation
{
    public class AddEditLocationCommand : IRequest<Unit>
    {
        public AddEditLocationCommand(LocationModel locationModel)
        {
            LocationModel = locationModel;
        }

        public LocationModel LocationModel { get; set; }
    }
}
