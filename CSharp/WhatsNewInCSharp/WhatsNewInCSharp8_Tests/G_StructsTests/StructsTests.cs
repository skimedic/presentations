using System;
using System.Collections.Generic;
using System.Text;
using WhatsNewInCSharp8.G_Structs;
using Xunit;

namespace WhatsNewInCSharp8_Tests.G_StructsTests
{
    public class StructsTests
    {
        [Fact]
        public void ShouldDisposeStruct()
        {
            using var sut = new DisposablePoint();

        }
    }
}
