// Copyright Information
// =============================
// BehavioralPatterns - IPizza.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================
using System.Collections.Generic;

namespace BehavioralPatterns.TemplateMethod
{
    public enum DoughType
    {
        None,
        Thin,
        Pan,
        DeepDish
    }
    public interface IPizza
    {
        IList<string> Toppings { get; }
        DoughType Dough { get; }
        string Seasonings { get; }
        string SauceType { get; }

    }
    public class ThinCrustPizza : IPizza
    {
        private IList<string> _toppings;
        public IList<string> Toppings => _toppings;
        public DoughType Dough => DoughType.Thin;
        public string Seasonings { get; }
        public string SauceType { get; }
    }


}