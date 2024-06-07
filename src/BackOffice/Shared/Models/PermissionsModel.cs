namespace BackOffice.Shared.Models
{
    public class PermissionsModel
    {
        public PermissionsModel(string name, string description, string code)
        {
            Name = name;
            Description = description;
            Code = code;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        public override bool Equals(object o)
        {
            var other = o as PermissionsModel;
            return other?.Name == Name;
        }

        public override int GetHashCode() => Name.GetHashCode();
    }
}
