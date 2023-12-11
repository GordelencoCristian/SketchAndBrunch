using MediatR;

namespace BackOffice.Server.Application.UserProfile.AddUserProfile
{
    public class AddUserProfileCommand : IRequest<int>
    {
        public string Name { get; set; }    
    }
}
