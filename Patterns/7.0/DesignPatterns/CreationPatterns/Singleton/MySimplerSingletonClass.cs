// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - MySimplerSingletonClass.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace CreationPatterns.Singleton;

public sealed class MySimplerSingletonClass 
{
    static MySimplerSingletonClass() { }
    private MySimplerSingletonClass() { }

    public static MySimplerSingletonClass Instance { get; } = new MySimplerSingletonClass();

    //This doesn't work, despite several SO posts
    //public static MySimplerSingletonClass Instance => new MySimplerSingletonClass();

    public int SomeValue { get; set; }
}