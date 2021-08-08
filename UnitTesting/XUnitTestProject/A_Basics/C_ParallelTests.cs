#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - C_ParallelTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using System.Threading;
using Xunit;

namespace XUnitTestProject.A_Basics
{
    /*
    NOTE: All classes should NOT be in one file. This is demo code, so we will allow it to slide.

    Put all test classes into a single test collection by default:
      [assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]
    Default: CollectionBehavior.CollectionPerClass
    Set the maximum number of threads to use when running test in parallel:
      [assembly: CollectionBehavior(MaxParallelThreads = n)]
    Default: number of virtual CPUs in the PC
    Turn off parallelism inside the assembly:
      [assembly: CollectionBehavior(DisableTestParallelization = true)]
    Default: false

         */
    [Collection("Foo")]
    public class TestClass1
    {
        [Fact]
        public void Test1()
        {
            Thread.Sleep(3000);
        }

        [Fact]
        public void Test2()
        {
            Thread.Sleep(3000);
        }
    }

    public class TestClass2
    {
        [Fact]
        public void Test1()
        {
            Thread.Sleep(3000);
        }
    }

    public class TestClass3
    {
        [Fact]
        public void Test1()
        {
            Thread.Sleep(3000);
        }
    }

    [Collection("Serialize")]
    public class TestClass4
    {
        [Fact]
        public void Test1()
        {
            Thread.Sleep(3000);
        }
    }

    [Collection("Serialize")]
    public class TestClass4a
    {
        [Fact]
        public void Test1()
        {
            Thread.Sleep(3000);
        }
    }
}