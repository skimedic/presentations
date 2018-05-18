using System.Text;

namespace DesignPatterns.Behavioral.Command
{
    public interface IAppCommand
    {
        StringBuilder Sb { get; set; }
        void Execute(string text);
        void UnExecute();
    }
}