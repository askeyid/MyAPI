using Newtonsoft.Json;
using RestSharp;

namespace API.Automation.Utility
{
    public class HandleContent
    {
        public static T GetContent<T>(RestResponse response)
        {
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
