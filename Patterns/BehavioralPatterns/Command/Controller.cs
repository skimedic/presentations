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
using System.Security.Policy;
using System.Text;

namespace BehavioralPatterns.Command
{
    public class Controller
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
	    private readonly List<IAppCommand> _commands = new List<IAppCommand>();

        public IAppCommand GetCommandAt(int x)
        {
            return _commands[x];
        }
        public int AddCommand(IAppCommand command)
        {
            command.Sb = _stringBuilder;
            _commands.Add(command);
            return _commands.IndexOf(command);
        }
        public void RemoveCommand(int position)
        {
            _commands.RemoveAt(position);
        }

        public string GetBuiltString()
        {
            return _stringBuilder.ToString();
        }
    }
}