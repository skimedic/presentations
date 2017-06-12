#region copyright
// Copyright Information
// ==============================
// PatternsExamples - LightCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

using System.Collections.Generic;
using System.Text;

namespace BehavioralPatterns.Command
{
    public class AddTextCommand : IAppCommand
    {
        private readonly StringBuilder _sb;
        private readonly List<string> _entries = new List<string>();
        public AddTextCommand(StringBuilder sb)
        {
            _sb = sb;
        }

        public void Execute(string textToAdd)
        {
            _sb.Append(textToAdd);
            _entries.Add(textToAdd);
        }

        public void UnExecute()
        {
            //Should add error checking here
            _sb.Remove(_sb.Length, _entries[_entries.Count - 1].Length);
            _entries.RemoveAt(_entries.Count-1);
        }
    }
}