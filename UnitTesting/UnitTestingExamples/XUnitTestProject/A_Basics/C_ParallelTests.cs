// Copyright Information
// =============================
// XUnitTestProject - C_ParallelTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using System.Threading;
using Xunit;

namespace XUnitTestProject.A_Basics
{
    /*
    
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