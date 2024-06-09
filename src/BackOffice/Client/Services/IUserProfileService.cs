using BackOffice.Shared.Models;

namespace BackOffice.Client.Services
{
    public interface IUserProfileService
    {
        Task<int> AddEditUserProfile(UserProfileModel userProfileModel);
        Task<List<UserProfileModel>> GetUserProfiles();
    }
}
