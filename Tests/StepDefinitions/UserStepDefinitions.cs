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
    public class UserStepDefinitions
    {
        private RestResponse? updateUserRes;
        private UpdateUserReq? updateUserReq;
        private ScenarioContext scenarioContext;
        //hardcoded. should be moved to config
        const string BASE_URL = "https://dummyapi.io/data/v1/";
        private HttpStatusCode statusCode;
        private APIClient api;

        public UserStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            api = new APIClient(BASE_URL);
        }

        [Given(@"Get update user payload ""([^""]*)""")]
        public void GivenGetUpdateUserPayload(string fileName)
        {
            string file = HandleContent.GetFilePath(fileName);
            var payload = HandleContent.ParseJson<UpdateUserReq>(file);
            scenarioContext.Add("updateUser_payload", payload);
        }

        [Given(@"Send request to update username")]
        public async Task GivenSendRequestToUpdateUsername()
        {
            updateUserReq = scenarioContext.Get<UpdateUserReq>("updateUser_payload");
            var userId = scenarioContext.Get<string>("user_id");
            updateUserRes = await api.UpdateUser<UpdateUserReq>(updateUserReq, userId);
        }

        [Then(@"Check firstname is updated")]
        public void ThenCheckFirstNameIsUpdated()
        {
            var updateUserResContent = /*updateUserRes == null ? throw new Exception("response cannot be null") : */HandleContent.GetContent<UpdateUserRes>(updateUserRes);

            Assert.IsTrue(updateUserResContent?.firstName == updateUserReq?.firstName);
        }

        [Then(@"Check lastname is updated")]
        public void ThenCheckLastNmaeIsUpdated()
        {
            var updateUserResContent = updateUserRes == null ? throw new Exception("response cannot be null") : HandleContent.GetContent<UpdateUserRes>(updateUserRes);

            Assert.IsTrue(updateUserResContent?.lastName == updateUserReq?.lastName);
        }

    }
}
