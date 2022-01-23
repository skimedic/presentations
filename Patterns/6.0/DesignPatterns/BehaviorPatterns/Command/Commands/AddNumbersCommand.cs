// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - AddNumbersCommand.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace BehaviorPatterns.Command.Commands;

public class AddNumbersCommand : BaseCommand<int>
{
    public AddNumbersCommand(int value) : base(value)
    {
        InternalValue = value;
    }

    public override int Add(int value)
    {
        Entries.Add(value);
        InternalValue += value;
        return Value;
    }
    public override int Remove()
    {
        //Should add error checking here
        var lastEntry = Entries[^1];
        InternalValue -= lastEntry;
        Entries.RemoveAt(Entries.Count-1);
        return Value;
    }
}