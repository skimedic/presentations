// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - Observer.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace BehaviorPatterns.Observer.B_NotifyPropertyChanged;

public class Observer
{
    private Subject _subject;
    public Observer()
    {
        _subject = new Subject();
        _subject.PropertyChanged += Subject_PropertyChanged;
    }

    private void Subject_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        //do something
    }
}