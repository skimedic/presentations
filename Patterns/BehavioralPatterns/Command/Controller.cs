#region copyright
// Copyright Information
// ==============================
// PatternsExamples - Controller.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

using System.Collections.Generic;

namespace BehavioralPatterns.Command
{
    public class Controller
    {
	    public List<IAppCommand> Commands { get; } = new List<IAppCommand>();
    }
}