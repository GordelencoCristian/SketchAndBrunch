using BackOffice.Server.Application.Requests.AddEditRequest;
using BackOffice.Server.Application.Requests.DeleteRequest;
using BackOffice.Server.Application.Requests.GetRequests;
using BackOffice.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RequestController : ControllerBase
    {
        private readonly ISender _sender;

        public RequestController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<int> AddEditRequest([FromBody] RequestModel requestModel)
        {
            return await _sender.Send(new AddEditRequestCommand(requestModel));
        }

        [HttpGet]
        public async Task<List<RequestModel>> GetRequests()
        {
            return await _sender.Send(new GetRequestsQuery());
        }

        [HttpPost]
        public async Task<Unit> DeleteRequest([FromBody] int requestId)
        {
            return await _sender.Send(new DeleteRequestCommand(requestId));
        }
    }
}
