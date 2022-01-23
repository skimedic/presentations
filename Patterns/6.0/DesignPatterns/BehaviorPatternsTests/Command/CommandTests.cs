// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatternsTests - CommandTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace BehaviorPatternsTests.Command;

[Collection("Command")]
public class CommandTests
{
    [Theory]
    [InlineData(12,5)]
    public void ShouldAddNumbers(int initValue, int firstAdd)
    {
        var addNumbersCommand = new AddNumbersCommand(initValue);
        addNumbersCommand.Add(firstAdd);
        Assert.Equal(initValue+firstAdd,addNumbersCommand.Value);
    }
    [Theory]
    [InlineData(12,5)]
    public void ShouldUndoAddingNumbers(int initValue, int firstAdd)
    {
        var addNumbersCommand = new AddNumbersCommand(initValue);
        addNumbersCommand.Add(firstAdd);
        addNumbersCommand.Remove();
        Assert.Equal(initValue,addNumbersCommand.Value);
    }
    [Theory]
    [InlineData("Patterns"," are fun")]
    public void ShouldAddText(string initValue, string firstAdd)
    {
        var addTextCommand = new AddTextCommand(initValue);
        addTextCommand.Add(firstAdd);
        Assert.Equal($"{initValue}{firstAdd}",addTextCommand.Value);
    }
    [Theory]
    [InlineData("Patterns"," are fun")]
    public void ShouldUndoText(string initValue, string firstAdd)
    {
        var addTextCommand = new AddTextCommand(initValue);
        addTextCommand.Add(firstAdd);
        addTextCommand.Remove();
        Assert.Equal(initValue,addTextCommand.Value);
    }
}