using System;
using System.Globalization;
using TechTalk.SpecFlow;

namespace SpecFlow.Example.StepArgumentTransformation
{
    [Binding]
    public class AustrianLocalizationTransformer
    {
        [StepArgumentTransformation]
        public double TransformDouble(string expr)
        {
            return Convert.ToDouble(expr, CultureInfo.GetCultureInfo("de-AT"));
        }      
        
        [StepArgumentTransformation]
        public DateTime TransformDate(string expr)
        {
            return Convert.ToDateTime(expr, CultureInfo.GetCultureInfo("de-AT"));
        }
    }
}