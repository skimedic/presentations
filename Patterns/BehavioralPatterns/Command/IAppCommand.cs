#region copyright
// Copyright Information
// ==============================
// PatternsExamples - IAppCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

using System.Text;

namespace BehavioralPatterns.Command
{
    public interface IAppCommand
    {
        StringBuilder Sb { get; set; }
        void Execute(string text);
        void UnExecute();
    }
}