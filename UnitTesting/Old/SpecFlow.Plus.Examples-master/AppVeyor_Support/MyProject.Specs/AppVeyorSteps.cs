using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyProject.Specs
{
    [Binding]
    public class AppVeyorSteps
    {
        [Given(@"I have a passing SpecFlow project")]
        public void GivenIHaveAPassingSpecFlowProject()
        {
        }

        [When(@"an AppVeyor build is executed")]
        public void WhenAnAppVeyorBuildIsExecuted()
        {
        }

        [Then(@"the tests are run and everything passed")]
        public void ThenTheTestsAreRunAndEverythingPassed()
        {
        }

        [Given(@"I have a failing SpecFlow project")]
        public void GivenIHaveAFailingSpecFlowProject()
        {
            throw new Exception("Failing SpecFlow project");
        }

        [Then(@"the tests are run and it failed")]
        public void ThenTheTestsAreRunAndItFailed()
        {
        }

        [Given(@"I have a SpecFlow project which has not all step bound")]
        public void GivenIHaveASpecFlowProjectWhichHasNotAllStepBound()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the tests are run and it is inconclusive")]
        public void ThenTheTestsAreRunAndItIsInconclusive()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
