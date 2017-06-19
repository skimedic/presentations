// Copyright Information
// =============================
// BehavioralPatterns - ICustomObserver.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using System.Collections.Generic;

namespace BehavioralPatterns.Observer.A_FromScratch
{
    public interface ICustomObserver
    {
        void Update(GameResult result);
        List<GameResult> Results { get; set; }

    }
    public class NewsPaper : ICustomObserver
    {
        public void Update(GameResult result)
        {
            Results.Add(result);
        }
        public List<GameResult> Results { get; set; } = new List<GameResult>();
    }
    public class RadioStation : ICustomObserver
    {
        public void Update(GameResult result)
        {
            Results.Add(result);
        }
        public List<GameResult> Results { get; set; } = new List<GameResult>();
    }

}