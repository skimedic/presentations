#region Copyright
// Copyright Information
// ==================================
// UnitTesting - MachineSpecTestProjectFullDotNet - SampleService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using System;

namespace MachineSpecTestProjectFullDotNet.SystemUnderTest
{
    public class SampleService : IDisposable
    {
        public SampleToken Authenticate(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName),"Missing userName");
            }
            return new SampleToken { UserName = userName, Password = password };
        }

        public void Dispose()
        {
            
        }
    }
}