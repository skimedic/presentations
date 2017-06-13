#region copyright
// Copyright Information
// ==============================
// PatternsExamplesTests - B_CommandTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

using BehavioralPatterns.Memento;
using Xunit;

namespace BehavioralPatternsTests.Memento
{
    [Collection("Memento")]
    public class MementoTests
    {
        [Fact]
        public void ShouldUpdateTheCustomersName()
        {
            var cust = new Customer {Id = 5, Name = "John Doe"};
            var cmd = new ChangeCustomerCommand(cust);
            var newName = "Billy Bob";
            cmd.Execute(newName);
            Assert.Equal(newName,cmd.Customer.Name);
        }
        [Fact]
        public void ShouldRollBackTheChange()
        {
            var originalName = "John Doe";
            var cust = new Customer {Id = 5, Name = originalName};
            var cmd = new ChangeCustomerCommand(cust);
            var newName = "Billy Bob";
            cmd.Execute(newName);
            cmd.UnExecute();
            Assert.Equal(originalName,cmd.Customer.Name);
        }
    }
}