using BackOffice.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using BackOffice.Shared.Validators;

namespace BackOffice.Shared.Models
{
    public class UserProfileModel
    {
        public int? Id { get; set; }
        public int? Number { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [CustomPhoneNumberValidator(ErrorMessage = "Required")]
        public string PhoneNumber { get; set; }

        [Required]
        public GenderEnumModel Gender { get; set; }


        [Required] 
        public DateTime? BirthDay { get; set; } = null;

        [Required]
        public RoleModel Role { get; set; }

        public CountryModel? Country { get; set; }

        //public SelectItem<int> Role { get; set; }

        public string? AvatarBase64 { get; set; }
    }
}
