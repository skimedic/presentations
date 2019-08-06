// Copyright Information
// =============================
// BehavioralPatterns - IDbCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================
namespace BehavioralPatterns.Memento
{
    public interface IDbCommand
    {
        void Execute(string text);
        void UnExecute();
    }
}