// Copyright Information
// =============================
// PatternsExamples - IHero.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
namespace PatternsExamples.C_Behavioral.Strategy
{
    public interface IHero
    {
        string DoHeroStuff();

        void ChangeSuperPower(ISuperPower power);
    }
}