using Microsoft.AspNetCore.Builder;

namespace SpyStore_v20.Controllers.Middleware
{
    public class MyMiddleWareItem
    {
        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseResponseCompression();
        }
    }
}