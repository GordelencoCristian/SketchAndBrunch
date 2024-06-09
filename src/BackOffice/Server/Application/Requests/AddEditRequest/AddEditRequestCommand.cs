using BackOffice.Shared.Models;
using MediatR;

namespace BackOffice.Server.Application.Requests.AddEditRequest
{
    public class AddEditRequestCommand : IRequest<int>
    {
        public AddEditRequestCommand(RequestModel requestModel)
        {
            RequestModel = requestModel;
        }

        public RequestModel RequestModel { get; set; }
    }
}
