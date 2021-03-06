using System;
using TechTalk.SpecFlow;
using Xunit;

namespace Shouty.Specs.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        private Person lucy = new Person("Lucy");
        private Person sean = new Person("Sean");
        private string messageFromSean;

        [Given("{Person} is located/standing {int} metre(s) from Sean")]
        public void GivenPersonIsLocatedMetresFromSean(Person person, int distance)
        {
            person.MoveTo(distance);
        }

        [When("{Person} shouts {string}")]
        public void WhenShouterShouts(Person shouter, string message)
        {
            shouter.Shout(message);
            messageFromSean = message;
        }

        [Then("Lucy should hear Sean's message")]
        public void ThenLucyShouldHearSeansMessage()
        {
            Assert.Contains(messageFromSean, lucy.GetMessagesHeard());
        }
    }
}
