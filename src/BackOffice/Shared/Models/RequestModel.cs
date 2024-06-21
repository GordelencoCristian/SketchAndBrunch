using System.ComponentModel.DataAnnotations;
using SharedData.Enums;
using SharedData.Models;

namespace BackOffice.Shared.Models
{
    public class RequestModel
    {
        public int? Id { get; set; }
        public DateTime? ApplicationDateTime { get; set; }
        public RequestStatusEnumModel? Status { get; set; }

        [Required]
        public UserProfileModel? UserProfile { get; set; }

        public ApplicantUserModel? ApplicantUser { get; set; }
        [Required]
        public EventModel? Event { get; set; }
    }
}
