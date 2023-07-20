namespace API.Automation.Models.Response
{
    public class CreateUserRes
    {
        public string? id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public DateTime? registerDate { get; set; }
        public DateTime? updatedDate { get; set; }
    }
}
