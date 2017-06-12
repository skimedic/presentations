#region copyright
// Copyright Information
// ==============================
// PatternsExamples - IAppCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

namespace BehavioralPatterns.Memento
{
    public interface IDbCommand
    {
        void Execute(string text);
        void UnExecute();
    }
}