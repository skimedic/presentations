using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhatsNewInCSharp8.H_AsyncStreams
{
    public class AsyncStreams
    {
        public async IAsyncEnumerable<string> GetNamesAsync()
        {
            string[] names = { "Archimedes", "Pythagoras", "Euclid", "Socrates", "Plato" };
            foreach (var name in names)
            {
                await Task.Delay(1000);
                yield return name;
            }
        }
        public async void UseTheNewType()
        {
            await foreach (var name in GetNamesAsync())
            {
                //WriteLine(name);
            }
        }
    }
}
