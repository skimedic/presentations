// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - IAppCommand.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace BehaviorPatterns.Command.Interfaces;

public interface IAppCommand<T>
{
    public T Value { get; }
    T Add(T value);
    T Remove();
}