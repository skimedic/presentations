using EFCoreSamples.Context;
using EFCoreSamples.Models;

namespace EFCoreSamples.Repos
{
    public class BloggingRepo : RepoBase<Blog>, IBloggingRepo
    {

        public BloggingRepo(BloggingContext context) : base(context)
        {
        }
    }
}