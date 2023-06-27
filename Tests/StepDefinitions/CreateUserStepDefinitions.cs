using API.Automation;
using API.Automation.Models.Request;
using API.Automation.Models.Response;
using API.Automation.Utility;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace Tests.StepDefinitions
{
    [Binding]
    public class CreateUserStepDefinitions
    {
        private CreateUserReq createUserReq;
        private RestResponse response;
        private ScenarioContext scenarioContext;
        //hardcoded. should be moved to config
        const string BASE_URL = "https://dummyapi.io/data/v1/";
        private HttpStatusCode statusCode;

        public CreateUserStepDefinitions(CreateUserReq createUserReq, ScenarioContext scenarioContext)
        {
            this.createUserReq = createUserReq;
            this.scenarioContext = scenarioContext;
        }

        [Given(@"User with first name ""([^""]*)""")]
        public void GivenUserWithFirstName(string firstName)
        {
            createUserReq.firstName = firstName;
        }

        [Given(@"User with second name ""([^""]*)""")]
        public void GivenUserWithSecondName(string lastName)
        {
            createUserReq.lastName = lastName;
        }

        [Given(@"User with ""([^""]*)"" email")]
        public void GivenUserWithEmail(string email)
        {
            createUserReq.email = email;
        }

        [When(@"Send request to create user")]
        public async Task WhenSendRequestToCreateUser()
        {
            var api = new APIClient(BASE_URL);
            response = await api.CreateUser<CreateUserReq>(createUserReq);
        }

        [Then(@"Validate (.*) code")]
        public void ThenValidateCode(int p0)
        {
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Assert.IsTrue(200 == code, $"Expected 200 code, but got {code}. Response body: {response.Content}");

            var content = HandleContent.GetContent<CreateUserRes>(response);
            Assert.IsTrue(createUserReq.firstName == content.firstName);
            Assert.IsTrue(createUserReq.lastName == content.lastName);
            Assert.IsTrue(createUserReq.email == content.email);
        }
    }
}
