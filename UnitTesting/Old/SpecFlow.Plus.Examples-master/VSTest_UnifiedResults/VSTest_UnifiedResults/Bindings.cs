using TechTalk.SpecFlow;

namespace VSTest_UnifiedResults
{
    [Binding]
    class Bindings
    {
        private static int _runCounter;

        [Given(@"a always working scenario")]
        public void GivenAAlwaysWorkingScenario()
        {

        }

        [Given(@"a scenario that only works the second time")]
        public void GivenAScenarioThatOnlyWorksTheSecondTime()
        {
            _runCounter++;

            if (_runCounter == 1)
            {
                throw new System.Exception("This scenario doesn't work the first time it runs");
            }
        }

    }
}
