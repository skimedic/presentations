#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - B_ClassFixtures.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
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
            //Session Setup
            Name = "Skimedic";
        }

        public void Dispose()
        {
            //Session Teardown
            Name = string.Empty;
        }

    }
}