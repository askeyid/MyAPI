using API.Automation.Auth;
using RestSharp;

namespace API.Automation
{
    public class APIClient : IAPIClient, IDisposable
    {
        readonly RestClient client;

        public APIClient(string baseUrl)
        {
            var options = new RestClientOptions(baseUrl)
            {
                Authenticator = new APIAuthenticator()
            };

            client = new RestClient(options);
        }

        public async Task<RestResponse> CreateUser<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.CREATE_USER, Method.Post);
            request.AddBody(payload);
            var response = await client.PostAsync(request);
            return response ?? throw new Exception("expected Create User response is not null");
        }

        public async Task<RestResponse> DeleteUser(string id)
        {
            var request = new RestRequest(Endpoints.DELETE_USER, Method.Delete);
            request.AddUrlSegment("id", id);
            return await client.ExecuteAsync(request);
        }

        public void Dispose()
        {
            client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<RestResponse> GetListOfUsers()
        {
            var request = new RestRequest(Endpoints.GET_LIST_OF_USERS, Method.Get);
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> GetUser(string id)
        {
            var request = new RestRequest(Endpoints.GET_USER, Method.Get);
            request.AddUrlSegment("id", id);
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> UpdateUser<T>(T payload, string id) where T : class
        {
            var request = new RestRequest(Endpoints.UPDATE_USER, Method.Put);
            request.AddUrlSegment("id", id);
            request.AddBody(payload); 
            return await client.ExecuteAsync<T>(request);
        }
    }
}
