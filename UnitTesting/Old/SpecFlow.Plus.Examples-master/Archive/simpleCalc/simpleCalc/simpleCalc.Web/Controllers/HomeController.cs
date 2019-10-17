using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using simpleCalc.PCL;
using simpleCalc.Web.Models;

namespace simpleCalc.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly MainViewModel mainViewModel = new MainViewModel();

        public ActionResult Index(CalcModel calcModel)
        {
            mainViewModel.Operand1 = calcModel.Operand1;
            mainViewModel.Operand2 = calcModel.Operand2;

            mainViewModel.PlusOperator = false;
            mainViewModel.MinusOperator = false;
            mainViewModel.MultiplyOperator = false;
            mainViewModel.DivideOperator = false;

            if (!String.IsNullOrWhiteSpace(calcModel.Function))
            {
                switch (calcModel.Function.ToUpper())
                {
                    case "PLUS":
                        mainViewModel.PlusOperator = true;
                        break;
                    case "MINUS":
                        mainViewModel.MinusOperator = true;
                        break;
                    case "MULTIPLY":
                        mainViewModel.MultiplyOperator = true;
                        break;
                    case "DIVIDE":
                        mainViewModel.DivideOperator = true;
                        break;
                }

                mainViewModel.CalcCommand.Execute(null);
            }

            calcModel.Result = mainViewModel.Result;


            return View("Index", calcModel);
        }
    }
}