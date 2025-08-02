// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - BaseCommand.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace BehaviorPatterns.Command.Base;

public abstract class BaseCommand<T> : IAppCommand<T>
{
    protected T InternalValue;
    protected BaseCommand(T value)
    {
        InternalValue = value;
    }

    public T Value => InternalValue;
    protected readonly List<T> Entries = new();
    public abstract T Add(T value);
    public abstract T Remove();
}