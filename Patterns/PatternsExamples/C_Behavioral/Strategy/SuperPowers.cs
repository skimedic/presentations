#region copyright
// Copyright Information
// ==============================
// PatternsExamples - SuperPowers.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

namespace PatternsExamples.C_Behavioral.Strategy
{
    public interface ISuperPower
    {
        string ExercisePower();
    }

    public class RegularJoe : ISuperPower
    {
        public string ExercisePower() => "Run away";
    }

    public class Fly : ISuperPower
    {
        public string ExercisePower() => "Up, Up, and Away!";
    }

    public class Fight : ISuperPower
    {
        public string ExercisePower() => "KaBaam!";
    }

    public class WeaveWeb : ISuperPower
    {
        public string ExercisePower() => "Catches Thieves Like Flies!";
    }
}