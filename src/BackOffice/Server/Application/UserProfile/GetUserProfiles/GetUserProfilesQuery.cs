using BackOffice.Shared.Models;
using MediatR;

namespace BackOffice.Server.Application.UserProfile.GetUserProfiles
{
    public class GetUserProfilesQuery : IRequest<List<UserProfileModel>>
    {
    }
}
