using WhatsNewInCSharp8.H_AsyncStreams;
using Xunit;

namespace WhatsNewInCSharp8_Tests.C_IAsyncEnumerable
{
    public class AsyncStreamsTests
    {
        [Fact]
        public async void ShouldUseAsyncInForEach()
        {
            var sut = new AsyncStreams();
            await foreach (var name in sut.GetNamesAsync())
            {
                //WriteLine(name);
            }
        }
    }
}
