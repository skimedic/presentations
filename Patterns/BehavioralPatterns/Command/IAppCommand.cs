#region copyright
// Copyright Information
// ==============================
// PatternsExamples - IAppCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

namespace BehavioralPatterns.Command
{
    public interface IAppCommand
    {
        void Execute(string text);
        void UnExecute();
    }
}