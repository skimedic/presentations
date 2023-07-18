// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - Subject.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BehaviorPatterns.Observer.B_NotifyPropertyChanged;

public class Subject : INotifyPropertyChanged
{
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            if (value != _name)
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}