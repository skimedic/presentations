// Copyright Information
// =============================
// PatternsExamples - BadAPIS.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
namespace PatternsExamples.B_Structural.B_Facade
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