// Copyright Information
// ==============================
// PatternsExamples - BadAPIS.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================

namespace StructuralPatterns.AdapterFacade.Facade
{
    public interface IOverdone
    {
        int DoSomething(int x, int y);

        int DoSomethingElse(int x, int y, int z);

        int DoSomethingAgain(int x, int y, int z, int a);
    }
    public interface IConfusing
    {
        int Execute(int a, int b, int c);

        int Method1();

        int Method2(int x);

        int Method2(int x, int y);
    }
}