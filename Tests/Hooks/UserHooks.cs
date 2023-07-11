using API.Automation;
using API.Automation.Models.Request;
using API.Automation.Models.Response;
using API.Automation.Utility;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;
using Tests.Context;

namespace Tests.Hooks
{
    [Binding]
    public sealed class UserHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private UserContext userContext;
        private RestResponse? response;
        private ScenarioContext scenarioContext;
        private APIClient api;
        const string BASE_URL = "https://dummyapi.io/data/v1/";
        private HttpStatusCode statusCode;
        private string? userId;

        public UserHooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.userContext = new UserContext();
            api = new APIClient(BASE_URL);
        }

        [BeforeScenario("user", Order = 0)]
        public async Task CreateUser()
        {
            response = await api.CreateUser<CreateUserReq>(userContext.createUserReq);
            userId = HandleContent.GetContent<CreateUserRes>(response).id;
            scenarioContext.Add("user_id", userId);
        }

        [BeforeScenario("user", Order = 1)]
        public void ValidateCreateUserResponse()
        {
            statusCode = response.StatusCode;
            var responseCode = (int)statusCode;
            Assert.IsTrue(200 == responseCode, $"Expected 200 code, but got {responseCode}. Response body: {response.Content}");
        }

        [AfterScenario("user")]
        public async Task DeleteUser()
        {
            var createUserResContent = HandleContent.GetContent<CreateUserRes>(response);
            response = await api.DeleteUser(createUserResContent.id);
            statusCode = response.StatusCode;
            var responseCode = (int)statusCode;
            Assert.IsTrue(200 == responseCode, $"Expected 200 code, but got {responseCode}. Response body: {response.Content}");
            var deleteUserResContent = HandleContent.GetContent<DeleteUserRes>(response);
            Assert.IsTrue(createUserResContent.id == deleteUserResContent.id);
        }
    }
}