#region copyright
// Copyright Information
// ==============================
// PatternsExamplesTests - B_CommandTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

using BehavioralPatterns.Command;
using Xunit;

namespace BehavioralPatternsTests.Command
{
    [Collection("Command")]
    public class CommandTests
    {
        [Fact]
        public void ShouldAddNumberssText()
        {
            var controller = new Controller();
            IAppCommand addNumbersCommand = new AddNumbersCommand();
            var addCommandReference = controller.AddCommand(addNumbersCommand);
            controller.GetCommandAt(addCommandReference).Execute("1234");
            Assert.Equal("1234",controller.GetBuiltString());
        }
        [Fact]
        public void ShouldUndoNumbersAsText()
        {
            var controller = new Controller();
            var addCommandReference = controller.AddCommand(new AddTextCommand());
            controller.GetCommandAt(addCommandReference).Execute("1234");
            controller.GetCommandAt(addCommandReference).Execute("5678");
            controller.GetCommandAt(addCommandReference).UnExecute();
            Assert.Equal("1234", controller.GetBuiltString());
        }
        [Fact]
        public void ShouldAddText()
        {
            var controller = new Controller();
            var addCommandReference = controller.AddCommand(new AddTextCommand());
            controller.GetCommandAt(addCommandReference).Execute("abc");
            controller.GetCommandAt(addCommandReference).Execute("abc");
            Assert.Equal("abcabc",controller.GetBuiltString());
        }
        [Fact]
        public void ShouldUndoText()
        {
            var controller = new Controller();
            var addCommandReference = controller.AddCommand(new AddTextCommand());
            controller.GetCommandAt(addCommandReference).Execute("abc");
            controller.GetCommandAt(addCommandReference).Execute("abc");
            controller.GetCommandAt(addCommandReference).UnExecute();
            Assert.Equal("abc",controller.GetBuiltString());
        }
    }
}