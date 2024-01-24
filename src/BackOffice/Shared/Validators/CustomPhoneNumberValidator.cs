using System.ComponentModel.DataAnnotations;

namespace BackOffice.Shared.Validators
{
    public class CustomPhoneNumberValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string phoneNumber = value as string;

            if (string.IsNullOrEmpty(phoneNumber))
            {
                // The field is required, so check if it's not null or empty
                return new ValidationResult("Phone number is required.");
            }

            if (phoneNumber.StartsWith("+40"))
            {
                // Check if the phone number starts with "+373" and has a total of 11 characters
                if (!phoneNumber.StartsWith("+40") || phoneNumber.Length != 12)
                {
                    return new ValidationResult("Phone number must start with +40 and have a total of 11 characters.");
                }
            }
            else
            {
                if (!phoneNumber.StartsWith("+373") || phoneNumber.Length != 12)
                {
                    return new ValidationResult("Phone number must start with +373 and have a total of 11 characters.");
                }
            }


            return ValidationResult.Success;
        }
    }
}
