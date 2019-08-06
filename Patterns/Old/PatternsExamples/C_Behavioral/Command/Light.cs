// Copyright Information
// =============================
// PatternsExamples - Light.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternsExamples.C_Behavioral.Commands
{
    public class Light : ILight
    {
        public bool LightIsOn { get; set; }
    }
}
