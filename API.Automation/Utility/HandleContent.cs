﻿using Newtonsoft.Json;
using RestSharp;

namespace API.Automation.Utility
{
    public class HandleContent
    {
        public static T? GetContent<T>(RestResponse response, bool expectedNonNullContent = true)
        {
            var responseContent = response?.Content;
            
            if (responseContent != null)
            {
                var obj = JsonConvert.DeserializeObject<T>(responseContent);
                
                if (expectedNonNullContent)
                {
                    return obj == null ? throw new Exception("deserialization returns null") : obj;
                }

                return obj;
            }

            throw new Exception("Expected non-nullable response");
        }

        public static T? ParseJson<T>(string file)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }

        public static string ConvertToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string GetFilePath(string name)
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
            path = string.Format(path + "TestData\\{0}", name);
            return path;
        }
    }
}
