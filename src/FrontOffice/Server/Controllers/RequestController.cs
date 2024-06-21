using FrontOffice.Server.Application.Requests.AddRequest;
using FrontOffice.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FrontOffice.Server.Controllers
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
        public async Task<int> AddRequest([FromBody] RequestModel requestModel)
        {
            return await _sender.Send(new AddRequestCommand(requestModel));
        }
    }
}
