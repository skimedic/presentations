#region Copyright
// Copyright Information
// ==================================
// UnitTesting - MachineSpecTestProjectFullDotNet - B_CleanUpAfterEveryContext.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using Machine.Specifications;

namespace MachineSpecTestProjectFullDotNet.C_LifecycleOptions
{
    public class CleanUpAfterEveryContext : ICleanupAfterEveryContextInAssembly
    {
        public void AfterContextCleanup()
        {
            //Runs after every context in assembly 
            //eliminates need for repeated code in Cleanup 
            var foobar = "foobar";
        }
    }
}
