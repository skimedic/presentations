using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsNewInCSharp7.C_OutVariables
{
    public class OutVariableExamples
    {
        public bool OutVariables()
        {
            //C# 6
            int oldResult;
            bool oldCanParse = int.TryParse("123", out oldResult);
            //C# 7.0
            bool canParse = int.TryParse("123", out int result);
            bool canParse2 = int.TryParse("123", out var result2);

            if (bool.TryParse("true", out var boolResult))
            {
                //Do something
            }

            return boolResult;
        }

    }
}
