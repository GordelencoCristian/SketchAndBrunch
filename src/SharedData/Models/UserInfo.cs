namespace SharedData.Models
{
    public class UserInfo
    {
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public Dictionary<string, string> ExposedClaims { get; set; }
    }
}
