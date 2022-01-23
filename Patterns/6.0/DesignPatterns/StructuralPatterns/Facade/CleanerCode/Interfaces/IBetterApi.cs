// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - IBetterApi.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace StructuralPatterns.Facade.CleanerCode.Interfaces;

public interface IBetterApi
{
    int AddThreeNumbers(int firstParam, int secondParam, 
        int thirdParam);

    int AddThenMultiply(int addend1, int factor);

    int AddThenMultiply(int addend1, int addend2, int factor);

    int AddThenMultiply(int addend1, int addend2, int addend3, 
        int factor);
}