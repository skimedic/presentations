using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsNewInCSharp8.F_Interfaces
{

    public interface IPersonOld
    {
        string Name { get; set; }
        string City { get; set; }
    }

    public interface IPersonGetName
    {
        string GetName();
    }

    public class PersonOld : IPersonOld
    {
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class NewPersonOld : IPersonOld, IPersonGetName
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string GetName() => "Unknown Person";
    }
}
