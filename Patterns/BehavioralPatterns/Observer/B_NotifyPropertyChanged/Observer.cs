using System.ComponentModel;

namespace BehavioralPatterns.Observer.B_NotifyPropertyChanged
{
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
}