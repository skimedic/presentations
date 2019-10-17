using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace SpecialChars.Steps
{
    [Binding]
    class CheckSteps
    {
        private List<string> _specialChars = new List<string>()
        {
            "ä",
            "Ä",
            "ü",
            "Ü",
            "ö",
            "Ö",
            "Å",
            "ô",
            "é",
            "€",
            "$",
            "£",
            "á",
            "ã"
        };

        [Then(@"the special char '(.*)' is working")]
        public void ThenTheSpecialCharIsWorking(string specialChar)
        {
            _specialChars.Should().Contain(specialChar);
        }

    }
}
