using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Models;
using Repositories.Repos.Base;

namespace Repositories.Repos;

public class BlogRepo : RepoBase<Blog>, IBlogRepo
{
    public BlogRepo(BloggingContext context) : base(context)
    {
    }

    internal BlogRepo(DbContextOptions<BloggingContext> options) : base(options)
    {
    }

    //public IEnumerable<Blog> GetAllWithRelated()
    //{
    //    //Table.Include(x=>x.Author).ThenInclude()
    //    //    .Include()
    //}
    public override IEnumerable<Blog> GetAll() => 
        base.GetAll(new List<(Expression<Func<Blog, object>> orderBy, bool desc)> {(x => x.Name,false)});


}