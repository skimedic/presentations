// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - BetterApi.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace StructuralPatterns.Facade.CleanerCode;

public class BetterApi : IBetterApi
{
    private readonly IConfusing _confusing;
    private readonly IOverdone _overdone;

    public BetterApi()
    {
        //Demo Code
        _confusing = new Confusing();
        _overdone = new Overdone("foo");
    }

    public BetterApi(IConfusing confusing, IOverdone overdone)
    {
        _confusing = confusing;
        _overdone = overdone;
    }

    public int AddThreeNumbers(int firstParam, int secondParam, int thirdParam) 
        => _confusing.Execute(firstParam, secondParam, thirdParam);

    public int AddThenMultiply(int addend1, int factor) 
        => _overdone.DoSomething(addend1, factor);

    public int AddThenMultiply(int addend1, int addend2, int factor) 
        => _overdone.DoSomethingElse(addend1, addend2, factor);

    public int AddThenMultiply(int addend1, int addend2, int addend3, int factor) 
        => _overdone.DoSomethingAgain(addend1, addend2, addend3, factor);
}