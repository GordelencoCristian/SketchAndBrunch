using System.ComponentModel.DataAnnotations;

namespace BackOffice.Shared.Models
{
    public class RequestModel
    {
        public int? Id { get; set; }
        public DateTime? ApplicationDateTime { get; set; }
        [Required]
        public UserProfileModel? UserProfile { get; set; }
        [Required]
        public EventModel? Event { get; set; }
    }
}
