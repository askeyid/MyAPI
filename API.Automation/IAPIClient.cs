using RestSharp;

namespace API.Automation
{
    public interface IAPIClient
    {
        Task<RestResponse> CreateUser<T>(T payload) where T: class;
        Task<RestResponse> UpdateUser<T>(T payload, string id) where T: class;
        Task<RestResponse> DeleteUser(string id);
        Task<RestResponse> GetUser(string id);
        Task<RestResponse> GetListOfUsers();
    }
}
