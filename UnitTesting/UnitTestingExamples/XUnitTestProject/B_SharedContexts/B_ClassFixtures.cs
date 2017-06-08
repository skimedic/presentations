using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Xunit;

namespace XUnitTestProject.B_SharedContexts
{
    public class B_ClassFixtures : IDisposable
    {
        public int InstanceCount = 0;
        private string _name;

        public string Name
        {
            get => _name;
            private set
            {
                _name = value;
                InstanceCount++;
            }
        }

        public B_ClassFixtures()
        {
            Name = "Skimedic";
        }

        public void Dispose()
        {
            Name = string.Empty;
        }

    }
}