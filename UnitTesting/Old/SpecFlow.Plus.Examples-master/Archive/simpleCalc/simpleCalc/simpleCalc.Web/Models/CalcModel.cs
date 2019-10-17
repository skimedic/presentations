using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace simpleCalc.Web.Models
{
    public class CalcModel
    {
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public string Result { get; set; }
        public bool Plus { get; set; }
        public string Function { get; set; }
    }
}