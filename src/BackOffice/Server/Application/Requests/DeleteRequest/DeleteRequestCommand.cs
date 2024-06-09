using MediatR;

namespace BackOffice.Server.Application.Requests.DeleteRequest
{
    public class DeleteRequestCommand : IRequest<Unit>
    {
        public DeleteRequestCommand(int requestId)
        {
            RequestId = requestId;
        }

        public int RequestId { get; set; }
    }
}
