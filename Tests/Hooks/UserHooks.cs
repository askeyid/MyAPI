using API.Automation;
using API.Automation.Models.Request;
using API.Automation.Models.Response;
using API.Automation.Utility;
using BoDi;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using Tests.Context;

namespace Tests.Hooks
{
    [Binding]
    public sealed class UserHooks
    {
        private readonly UserContext userContext;
        private RestResponse? response;
        private readonly ScenarioContext scenarioContext;
        private readonly IAPIClient api;
        const string BASE_URL = "https://dummyapi.io/data/v1/";
        private HttpStatusCode statusCode;
        private string? userId;
        private readonly ISpecFlowOutputHelper outputHelper;
        
        public UserHooks(ScenarioContext scenarioContext, UserContext userContext, IObjectContainer objectContainer, ISpecFlowOutputHelper outputHelper)
        {
            this.scenarioContext = scenarioContext;
            this.userContext = userContext;
            this.outputHelper = outputHelper;
            api = new APIClient(BASE_URL);
            objectContainer.RegisterInstanceAs(api);
        }

        [Scope(Scenario = "Update user")]
        [Scope(Scenario = "Update user 2")]
        [BeforeScenario]
        public void SayHello()
        {
            outputHelper.WriteLine("--- Only for \"Update user\" scenario ---");
        }

        [BeforeScenario("user", Order = 1)]
        public async Task CreateUser()
        {
            outputHelper.WriteLine("--- Creating a user ---");
            response = await api.CreateUser<CreateUserReq>(userContext.createUserReq);
            userId = HandleContent.GetContent<CreateUserRes>(response)?.id;
            scenarioContext.Add("user_id", userId);
            outputHelper.WriteLine($"--- Created the user with \"{userId}\" id---");
        }

        [BeforeScenario("user", Order = 2)]
        public void ValidateCreateUserResponse()
        {
            outputHelper.WriteLine("--- Validating the user ---");
            statusCode = response.StatusCode;
            var responseCode = (int)statusCode;
            Assert.IsTrue(200 == responseCode, $"Expected 200 code, but got {responseCode}. Response body: {response.Content}");
            outputHelper.WriteLine("--- Validated the user ---");
        }

        [AfterScenario("user")]
        public async Task DeleteUser()
        {
            outputHelper.WriteLine("--- Deleting the user ---");
            var createUserResContent = HandleContent.GetContent<CreateUserRes>(response);
            response = await api.DeleteUser(createUserResContent.id);
            statusCode = response.StatusCode;
            var responseCode = (int)statusCode;
            Assert.That(responseCode, Is.EqualTo(200), $"Expected 200 code, but got {responseCode}. Response body: {response.Content}");
            var deleteUserResContent = HandleContent.GetContent<DeleteUserRes>(response);
            Assert.IsTrue(createUserResContent.id == deleteUserResContent.id);
            outputHelper.WriteLine($"--- Deleted the user with \"{userId}\" id---");
        }

        [BeforeStep, Scope(Tag = "markStep")]
        public void SetupStuffForSteps()
        {
            outputHelper.WriteLine("STARTED STEP: " + scenarioContext.StepContext.StepInfo.Text);
        }

        [BeforeStep, Scope(Tag = "markStep")]
        public void DownStuffForSteps()
        {
            outputHelper.WriteLine("FINISHED STEP: " + scenarioContext.StepContext.StepInfo.Text);
        }

        [BeforeScenario(Order = -1)]
        public void NUnitFixture()
        {
            outputHelper.WriteLine("NUnit test: " + scenarioContext.ScenarioInfo.Title);
        }
    }
}