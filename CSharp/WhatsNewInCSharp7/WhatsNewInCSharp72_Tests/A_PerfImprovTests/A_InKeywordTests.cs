using System.Runtime.CompilerServices;
using Xunit;

namespace WhatsNewInCSharp72_Tests.A_PerfImprovTests
{
    public class A_InKeywordTests
    {
        internal void AllowModification(int i)
        {
            i = 5;
        }
        //int is not a good candidate - in fact, performance might degrade
        internal void DontAllowModification(in int i)
        {
            //Compilation error
            //i = 5;
        }
        [Fact]
        public void ShouldNotAllowModificationWithIn()
        {

        }
    }
}
