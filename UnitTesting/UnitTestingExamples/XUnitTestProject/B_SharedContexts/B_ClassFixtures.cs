// Copyright Information
// =============================
// XUnitTestProject - B_ClassFixtures.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
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