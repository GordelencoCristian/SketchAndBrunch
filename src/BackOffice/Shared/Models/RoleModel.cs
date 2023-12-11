using System.ComponentModel.DataAnnotations;

namespace BackOffice.Shared.Models
{
    public class RoleModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public IEnumerable<string> Permistions { get; set; }
    }
}
