// Copyright Information
// =============================
// StructuralPatterns - Interfaces.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================
namespace DesignPatterns.Structural.AdapterFacade.Adapter
{
    //TODO: IRL separate these into their own files
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