using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;

namespace WhatsNewInCSharp8
{
    public class Foo
    {
        public void Method()
        {
            var test = 5;
            var test2 = test switch() {

            }
}
public class AsyncStreams
    {
        IAsyncEnumerable<int> foo;
    //    public async IAsyncEnumerable<int> GetBigResultsAsync()
    //    {
    //        await foreach (var result in GetResultsAsync())
    //        {
    //            if (result > 20) yield return result;
    //        }
    //    }
    //    public async IAsyncEnumerable<int> GetResultsAsync()
    //    {
    //        for (int i = 0; i < 100; i++)
    //        {
    //            await Task.Run(()=>Thread.Sleep(100));
    //            yield return i;
    //        }
    //    }
    }
}
