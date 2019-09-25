using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsNewInCSharp7.G_Misc
{
    public class MyClass
    {

    }
    public class ThrowExpressionDemos
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException("Oops");
        }

        internal MyClass NullInitializer()
        {
            return null;
        }
        public MyClass InitializeClassOldWay()
        {
            var myClass = NullInitializer();
            if (myClass == null)
            {
                throw new ArgumentNullException("Oops");
            }

            return myClass;
        }
        public MyClass InitializeClass()
        {
            return NullInitializer() ?? throw new ArgumentNullException("Oops");
        }

    }
}
