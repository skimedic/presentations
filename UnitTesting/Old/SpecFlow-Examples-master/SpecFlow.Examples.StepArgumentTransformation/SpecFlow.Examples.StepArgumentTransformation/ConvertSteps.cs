using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlow.Example.StepArgumentTransformation
{
    [Binding]
    public class ConvertSteps
    {
        [Given("I have entered (.*) into the system")]
        public void GivenIHaveEnteredSomethingIntoTheSystem(double number)
        {
            Assert.That(number, Is.EqualTo(1050.1));
        }

        [Given("the date is (.*)")]
        public void TheDateIs(DateTime dateTime)
        {
            Assert.That(dateTime, Is.EqualTo(new DateTime(2010,12,22)));
        }
    }
}
