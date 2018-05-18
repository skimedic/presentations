// Copyright Information
// =============================
// BehavioralPatternsTests - CommandTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using DesignPatterns.Behavioral.Command;
using Xunit;

namespace DesignPatternsTests.BehavioralTests.CommandTests
{
    [Collection("Command")]
    public class CommandTests
    {
        [Fact]
        public void ShouldAddNumbersAsText()
        {
            var controller = new Controller();
            IAppCommand addNumbersCommand = new AddNumbersCommand();
            var addCommandReference = controller.AddCommand(addNumbersCommand);
            var expected = "1234";
            controller.GetCommandAt(addCommandReference).Execute(expected);
            Assert.Equal(expected,controller.GetBuiltString());
        }
        [Fact]
        public void ShouldUndoNumbersAsText()
        {
            var controller = new Controller();
            var addCommandReference = controller.AddCommand(new AddNumbersCommand());
            var expected = "1234";
            controller.GetCommandAt(addCommandReference).Execute(expected);
            controller.GetCommandAt(addCommandReference).Execute("5678");
            controller.GetCommandAt(addCommandReference).UnExecute();
            Assert.Equal(expected, controller.GetBuiltString());
        }
        [Fact]
        public void ShouldAddText()
        {
            var controller = new Controller();
            var addCommandReference = controller.AddCommand(new AddTextCommand());
            var text1 = "abc";
            controller.GetCommandAt(addCommandReference).Execute(text1);
            var text2 = "def";
            controller.GetCommandAt(addCommandReference).Execute(text2);
            Assert.Equal($"{text1}{text2}",controller.GetBuiltString());
        }
        [Fact]
        public void ShouldUndoText()
        {
            var controller = new Controller();
            var addCommandReference = controller.AddCommand(new AddTextCommand());
            var expected = "abc";
            controller.GetCommandAt(addCommandReference).Execute(expected);
            controller.GetCommandAt(addCommandReference).Execute("def");
            controller.GetCommandAt(addCommandReference).UnExecute();
            Assert.Equal(expected,controller.GetBuiltString());
        }
    }
}