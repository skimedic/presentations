using System;

namespace WhatsNewInCSharp7.G_Misc
{
    public class ExpressionBodiedMemberDemos
    {
        private string _input;

        public string Input
        {
            get => _input;
            set => _input = value ?? "Default";
        }
        public ExpressionBodiedMemberDemos(string input) => _input = input;

        ~ExpressionBodiedMemberDemos() => Console.WriteLine("Finalized");
    }
}