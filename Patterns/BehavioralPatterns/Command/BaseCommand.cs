// Copyright Information
// =============================
// BehavioralPatterns - BaseCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using System.Collections.Generic;
using System.Text;

namespace BehavioralPatterns.Command
{
    //Note: It's bad form to have more than one item in a file, but we make concessions
    //for teaching purposes
    public interface IAppCommand
    {
        StringBuilder Sb { get; set; }
        void Execute(string text);
        void UnExecute();
    }

    public abstract class BaseCommand : IAppCommand
    {
        public StringBuilder Sb { get; set; }
        protected readonly List<string> Entries = new List<string>();
        public abstract void Execute(string text);

        public abstract void UnExecute();
    }
}