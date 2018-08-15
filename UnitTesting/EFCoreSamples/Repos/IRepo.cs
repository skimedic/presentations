using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCoreSamples.Context;

namespace EFCoreSamples.Repos
{
    public interface IRepo<T> : IDisposable
    {
        BloggingContext Context { get; }
        T Find(int id);
        int Add(T entity, bool persist = true);
        int AddRange(IEnumerable<T> entities, bool persist = true);
        int Update(T entity, bool persist = true);
        int UpdateRange(IEnumerable<T> entities, bool persist = true);
        int Delete(T entity, bool persist = true);
        int DeleteRange(IEnumerable<T> entities, bool persist = true);
        int SaveChanges();
    }
}
