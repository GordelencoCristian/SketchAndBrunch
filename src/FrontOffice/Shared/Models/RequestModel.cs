using SharedData.Models;
using System.ComponentModel.DataAnnotations;

namespace FrontOffice.Shared.Models
{
    public class RequestModel
    {
        [Required]
        public ApplicantUserModel ApplicantUser { get; set; } = new();

        [Required]
        public EventModel? Event { get; set; }
    }
}
