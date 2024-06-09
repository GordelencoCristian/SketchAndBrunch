using MediatR;

namespace BackOffice.Server.Application.UserProfile.DeleteUserProfile
{
    public class DeleteUserProfileCommand : IRequest<int>
    {
        public DeleteUserProfileCommand(int userProfileId)
        {
            UserProfileId = userProfileId;
        }

        public int UserProfileId { get; set; }
    }
}
