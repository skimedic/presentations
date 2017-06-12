using System.Collections.Generic;
using System.Text;

namespace BehavioralPatterns.Command
{
    public class AddNumbersCommand : IAppCommand
    {
        private readonly StringBuilder _sb;
        private readonly List<string> _entries = new List<string>();
        public AddNumbersCommand(StringBuilder sb)
        {
            _sb = sb;
        }
        public void Execute(string text)
        {
            _sb.Append(text);
            _entries.Add(text);
        }
        public void UnExecute()
        {
            //Should add error checking here
            _sb.Remove(_sb.Length, _entries[_entries.Count - 1].Length);
            _entries.RemoveAt(_entries.Count-1);
        }
    }
}