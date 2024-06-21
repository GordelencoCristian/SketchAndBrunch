using FrontOffice.Shared.Models;
using MediatR;

namespace FrontOffice.Server.Application.Requests.AddRequest
{
    public class AddRequestCommand : IRequest<int>
    {
        public AddRequestCommand(RequestModel requestModel)
        {
            RequestModel = requestModel;
        }

        public RequestModel RequestModel { get; set; }
    }
}
