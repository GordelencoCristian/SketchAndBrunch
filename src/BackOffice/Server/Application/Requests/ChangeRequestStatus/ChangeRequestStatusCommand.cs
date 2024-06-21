using BackOffice.Shared.Models;
using MediatR;

namespace BackOffice.Server.Application.Requests.ChangeRequestStatus
{
    public class ChangeRequestStatusCommand : IRequest<int>
    {
        public ChangeRequestStatusCommand(ChangeStatusModel model)
        {
            Model = model;
        }

        public ChangeStatusModel Model { get; set; }
    }
}
