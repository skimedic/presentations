#region copyright
// Copyright Information
// ==============================
// PatternsExamples - ICharacter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

namespace PatternsExamples.B_Structural.A_Adapter
{
    public interface ICharacter
    {
        int Chase();

        int Flee();

        int Attack();
    }

    public interface IFlyingSquirrel
    {
        int Fly();

        int DropAcorns();
    }

    public interface IMoose
    {
        int Run();

        int Charge();
    }

    public interface IBadGuy
    {
        int Drive();

        int Shoot();
    }
}