namespace API.Automation.Models.Response
{
    public class ListOfUsersRes
    {
        public Data[]? data { get; set; }
        public int? total { get; set; }
        public int? page { get; set; }
        public int? limit { get; set; }
    }

    public class Data
    {
        public string? id { get; set; }
        public string? title { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? picture { get; set; }
    }
}
