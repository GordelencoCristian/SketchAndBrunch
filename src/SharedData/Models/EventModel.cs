using System.ComponentModel.DataAnnotations;

namespace SharedData.Models
{
    public class EventModel
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime EventTime { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int NumberOfparticipants { get; set; }
        [Required]
        public LocationModel Location { get; set; }

    }
}
