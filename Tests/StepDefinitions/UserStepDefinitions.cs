using API.Automation;
using API.Automation.Models.Request;
using API.Automation.Models.Response;
using API.Automation.Utility;
using BoDi;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Assist.Attributes;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.UnitTestProvider;

namespace Tests.StepDefinitions
{
    [Binding, Scope(Tag = "user")]
    public class UserStepDefinitions
    {
        private RestResponse? updateUserRes;
        private UpdateUserReq? updateUserReq;
        private readonly ScenarioContext scenarioContext;
        private readonly IAPIClient api;
        private readonly IUnitTestRuntimeProvider unitTestRuntimeProvider;
        private readonly ISpecFlowOutputHelper outputHelper;

        public UserStepDefinitions(ScenarioContext scenarioContext, IObjectContainer objectContainer, IUnitTestRuntimeProvider unitTestRuntimeProvider, ISpecFlowOutputHelper outputHelper)
        {
            this.scenarioContext = scenarioContext;
            api = objectContainer.Resolve<IAPIClient>();
            this.unitTestRuntimeProvider = unitTestRuntimeProvider;
            this.outputHelper = outputHelper;
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
            var updateUserResContent = updateUserRes == null ? throw new Exception("response cannot be null") : HandleContent.GetContent<UpdateUserRes>(updateUserRes);
            Assert.That(updateUserResContent?.firstName, Is.EqualTo(updateUserReq?.firstName));
        }

        [Then(@"Check lastname is updated")]
        public void ThenCheckLastNameIsUpdated()
        {
            var updateUserResContent = updateUserRes == null ? throw new Exception("response cannot be null") : HandleContent.GetContent<UpdateUserRes>(updateUserRes);
            Assert.That(updateUserResContent?.lastName, Is.EqualTo(updateUserReq?.lastName));
        }

        [Given(@"Write (.*) phrase (.*) in console")]
        public void GivenWritePhraseInConsole(string phrase, string name)
        {
            outputHelper.WriteLine($"{phrase}, {name}!");
        }

        [Given(@"Write (\d+) two numbers (\d+) in console")]
        public void GivenWriteIntInConsole(int num1, int num2)
        {
            outputHelper.WriteLine($"Number1: {num1}, number2: {num2}!");
        }
        
        [Given(@"Parse (.*) into number")]
        public void GivenParseIntoNumber(int parsedString)
        {
            outputHelper.WriteLine(parsedString.GetType().FullName);
        }

        [Given(@"Parse (.*) into number"), Scope(Tag = "myScenario")]
        public void GivenParseIntoNumbers(int parsedString)
        {
            outputHelper.WriteLine(parsedString.GetType().FullName);
        }

        [StepArgumentTransformation(@"Parse (.*) into number")]
        public int TransformStringInInt(string number)
        {
            outputHelper.WriteLine(number.GetType().FullName);
            //bool parsed = int.TryParse(number, out int result);
            return int.TryParse(number, out int result) ? result : throw new Exception($"cannot parse string {number} to int");
        }

        [When(@"User enter creds")]
        public void WhenUserEnterCreds(Table table)
        {
            var collection = new List<Account>
            {
                new Account() { Name = "John Galt", HeightInInches = 73, BankAccountBalance = 1234.56m },
                new Account() { Name = "John Smith", HeightInInches = 72, BankAccountBalance = 1234.57m }
            };

            Assert.Multiple(() =>
            {
                Assert.That(table?.RowCount, Is.EqualTo(collection.Count));
                Assert.That(table?.ToProjection<Account>().Except(collection.ToProjection()).Count(), Is.EqualTo(0));
            });
        }

        [When(@"(.*) does something")]
        public void WhenPeterDoesSomething(string name)
        {
            unitTestRuntimeProvider.TestIgnore("not implemented");
        }
    }

    record Account
    {
        [TableAliases(@"First[\s*]?Name")]
        public string? Name { get; set; }
        public int HeightInInches { get; set; }
        public decimal BankAccountBalance { get; set; }
    }
}
