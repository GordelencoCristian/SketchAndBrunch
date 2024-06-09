using BackOffice.Shared.Models;
using MediatR;

namespace BackOffice.Server.Application.UserProfile.AddUserProfile
{
    public class AddUserProfileCommand : IRequest<int>
    {
        public AddUserProfileCommand(UserProfileModel userProfileModel)
        {
            UserProfileModel = userProfileModel;
        }

        public UserProfileModel UserProfileModel { get; set; }
    }
}
