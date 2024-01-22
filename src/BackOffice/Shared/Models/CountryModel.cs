namespace BackOffice.Shared.Models
{
    public class CountryModel
    {
        public CountryModel()
        {
            
        }
        public CountryModel(string name, string code, string phoneCode, string iconPath)
        {
            Name = name;
            Code = code;
            PhoneCode = phoneCode;
            IconPath = iconPath;
        }
        public string Name { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }
        public string IconPath { get; set; }
    }
}
