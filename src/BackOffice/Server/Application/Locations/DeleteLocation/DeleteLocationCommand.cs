using MediatR;

namespace BackOffice.Server.Application.Locations.DeleteLocation
{
    public class DeleteLocationCommand : IRequest<Unit>
    {
        public DeleteLocationCommand(int locationId)
        {
            LocationId = locationId;
        }

        public int LocationId { get; set; }
    }
}
