using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SpyStoreDAL.EfContext;
using SpyStoreModels.Models.Base;

namespace SpyStoreDAL.Repos.RepoBase
{
    public interface IRepo<T>  : IDisposable where T : EntityBase, new()
    {
        ApplicationDbContext Context { get; }
        int Count { get; }
        //bool HasChanges { get; }

        int Add(T entity, bool persist = true);
        int AddRange(IEnumerable<T> entities, bool persist = true);
        int Update(T entity, bool persist = true);
        int UpdateRange(IEnumerable<T> entities, bool persist = true);
        int Delete(T entity, bool persist = true);
        int DeleteRange(IEnumerable<T> entities, bool persist = true);
        //int Delete(int id, byte[] timeStamp, bool persist = true);
        int SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}