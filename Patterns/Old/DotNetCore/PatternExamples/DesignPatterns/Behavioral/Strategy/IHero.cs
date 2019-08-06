// Copyright Information
// =============================
// BehavioralPatterns - IHero.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================
namespace DesignPatterns.Behavioral.Strategy
{
    public interface IHero
    {
        string DoHeroStuff();

        void ChangeSuperPower(ISuperPower power);
    }
}