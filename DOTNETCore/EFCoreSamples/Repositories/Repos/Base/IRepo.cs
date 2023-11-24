using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Models.Base;

namespace Repositories.Repos.Base;

public interface IRepo<T> : IDisposable where T : EntityBase, new()
{
    DbSet<T> Table { get; }
    BloggingContext Context { get; }
    T Find(int? id);
    T FindAsNoTracking(int id);
    T FindIgnoreQueryFilters(int id);
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAll(IList<(Expression<Func<T, object>> orderBy, bool desc)> orders);
    IEnumerable<T> GetRange(IQueryable<T> query, int skip, int take);
    int Add(T entity, bool persist = true);
    int AddRange(IEnumerable<T> entities, bool persist = true);
    int Update(T entity, bool persist = true);
    int UpdateRange(IEnumerable<T> entities, bool persist = true);
    int Delete(T entity, bool persist = true);
    int DeleteRange(IEnumerable<T> entities, bool persist = true);
    int SaveChanges();
}