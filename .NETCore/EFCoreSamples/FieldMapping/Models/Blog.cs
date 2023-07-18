using System;
using System.Net.Http;

namespace FieldMapping.Models;

public class Blog
{
    private string _url;
    private string _name;

    public int BlogId { get; set; }

    public string Url
    {
        get { return _url; }
        set
        {
            if (_url == value)
            {
                return;
            }
            _url = value;
            PropertyChanged();
        }
    }

    //this will be used by EF when constituting an instance
    public string Name
    {
        get { return _name; }
        set
        {
            if (_name == value)
            {
                return;
            }
            _name = value;
            PropertyChanged();
        }
    }

    public void PropertyChanged()
    {
        Console.WriteLine("Property Changed");
    }
}