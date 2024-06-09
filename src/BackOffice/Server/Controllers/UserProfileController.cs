using BackOffice.Server.Application.UserProfile.AddUserProfile;
using BackOffice.Server.Application.UserProfile.DeleteUserProfile;
using BackOffice.Server.Application.UserProfile.GetUserProfiles;
using BackOffice.Server.Application.UserProfileRoles.DeleteUserProfileRoles;
using BackOffice.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserProfileController : ControllerBase
    {
        private readonly ISender _sender;

        public UserProfileController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<int> AddEditUserProfile([FromBody] UserProfileModel userProfileModel)
        {
            return await _sender.Send(new AddUserProfileCommand(userProfileModel));
        }

        [HttpGet]
        public async Task<List<UserProfileModel>> GetUserProfiles()
        {
            return await _sender.Send(new GetUserProfilesQuery());
        }

        [HttpPost]
        public async Task<int> DeleteUserProfile([FromBody] int userId)
        {
            return await _sender.Send(new DeleteUserProfileCommand(userId));
        }
    }
}
