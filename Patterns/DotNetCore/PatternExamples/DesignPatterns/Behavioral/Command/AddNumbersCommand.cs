// Copyright Information
// =============================
// BehavioralPatterns - AddNumbersCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================
namespace DesignPatterns.Behavioral.Command
{
    public class AddNumbersCommand : BaseCommand
    {
        //These methods do the same thing is this example, but are for 
        //demonstration purposes.  Real code would do different actions on execution
        public override void Execute(string value)
        {
            Sb.Append(value.ToString());
            Entries.Add(value.ToString());
        }
        public override void UnExecute()
        {
            //Should add error checking here
            var entryLength = Entries[Entries.Count - 1].Length;
            var totalLength = Sb.Length;
            Sb.Remove(totalLength - entryLength, entryLength);
            Entries.RemoveAt(Entries.Count - 1);
        }
    }
}