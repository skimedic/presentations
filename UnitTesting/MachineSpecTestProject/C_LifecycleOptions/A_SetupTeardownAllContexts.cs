#region Copyright
// Copyright Information
// ==================================
// UnitTesting - MachineSpecTestProject - A_SetupTeardownAllContexts.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using Machine.Specifications;

namespace MachineSpecTestProject.C_LifecycleOptions
{
    public class SetupTeardownAllContexts : IAssemblyContext
    {
        public void OnAssemblyStart()
        {
            //Runs before all specs
            var foo = "foo";
        }

        public void OnAssemblyComplete()
        {
            //runs after all specs;
            var bar = "bar";
        }


    }
}