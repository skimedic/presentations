using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsNewInCSharp8.F_Interfaces
{
    public interface IPerson
    {
        string Name { get; set; }
        string City { get; set; }

        public string GetName() => string.IsNullOrEmpty(Name) ? "Jane Doe" : Name;
    }

    public class Person : IPerson
    {
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class NewPerson : IPerson
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string GetName() => "Unknown Person";

    }
}
