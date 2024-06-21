using System.ComponentModel.DataAnnotations;
using SharedData.Validators.Validators;

namespace SharedData.Models
{
    public class ApplicantUserModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [CustomPhoneNumberValidator(ErrorMessage = "Required")]
        public string PhoneNumber { get; set; }
    }
}
