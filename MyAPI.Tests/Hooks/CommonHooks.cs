using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace Tests.Hooks
{
    [Binding]
    public sealed class CommonHooks
    {
        private readonly ScenarioContext scenarioContext;
        private readonly ISpecFlowOutputHelper outputHelper;

        public CommonHooks(ScenarioContext scenarioContext, ISpecFlowOutputHelper outputHelper)
        {
            this.scenarioContext = scenarioContext;
            this.outputHelper = outputHelper;
        }

        [AfterScenario]
        public void AddException()
        {
            Exception lastError = scenarioContext.TestError;

            if (lastError != null)
            {
                outputHelper.WriteLine($"Failure Details:\n{lastError?.ToString()}\n");
            }
        }
    }
}