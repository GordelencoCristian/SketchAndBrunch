using System.ComponentModel.DataAnnotations;

namespace BackOffice.Shared.Models
{
    public class RoleModel
    {
        public int? Id { get; set; }
        public int? Number { get; set; }
        [Required]
        public string Name { get; set; }
        public List<PermissionsModel> Permissions { get; set; } = new List<PermissionsModel>();
    }
}
