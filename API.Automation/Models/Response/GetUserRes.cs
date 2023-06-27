namespace API.Automation.Models.Response
{
    public class GetUserRes
    {
        public string id { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string picture { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string phone { get; set; }
        public Location location { get; set; }
        public DateTime registerDate { get; set; }
        public DateTime updatedDate { get; set; }
    }

    public class Location
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string timezone { get; set; }
    }

}
