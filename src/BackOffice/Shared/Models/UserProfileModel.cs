using BackOffice.Shared.Enums;
using BackOffice.Shared.Validators;
using System.ComponentModel.DataAnnotations;
using SharedData.Models.Reference;

namespace BackOffice.Shared.Models
{
    public class UserProfileModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [CustomPhoneNumberValidator(ErrorMessage = "Phone number must start with +373 and have a total of 11 characters.")]
        public string PhoneNumber { get; set; }

        [Required]
        public GenderEnumModel Gender { get; set; }

        [Required] 
        public DateTime? BirthDay { get; set; } = null;

        [Required]
        public RoleModel Role { get; set; }

        //public SelectItem<int> Role { get; set; }

        public string AvatarBase64 { get; set; }
    }
}
