#region copyright
// Copyright Information
// ==============================
// PatternsExamples - Light.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

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
