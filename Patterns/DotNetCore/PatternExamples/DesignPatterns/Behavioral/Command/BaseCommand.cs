// Copyright Information
// =============================
// BehavioralPatterns - BaseCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.Command
{
    public abstract class BaseCommand : IAppCommand
    {
        public StringBuilder Sb { get; set; }
        protected readonly List<string> Entries = new List<string>();
        public abstract void Execute(string text);

        public abstract void UnExecute();
    }
}