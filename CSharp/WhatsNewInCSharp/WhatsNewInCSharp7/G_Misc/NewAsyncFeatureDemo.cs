using System.Threading.Tasks;

namespace WhatsNewInCSharp7.G_Misc
{
    public class NewAsyncFeatureDemo
    {
        //must add System.Threading.Tasks.Extensions package
        public async ValueTask<int> GeneralAsyncReturnTypes()
        {
            await Task.Delay(100);
            return 5;
        }

        public ValueTask<int> CachedFunc()
        {
            return (_cache) ? new ValueTask<int>(_cacheResult) : new ValueTask<int>(LoadCache());
        }
        private bool _cache = false;
        private int _cacheResult;
        private async Task<int> LoadCache()
        {
            // simulate async work:
            await Task.Delay(100);
            _cacheResult = 100;
            _cache = true;
            return _cacheResult;
        }
    }
}