using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AutoLot.Dal.Repos.Base
{
    public interface IRepo<T>
    {
        int Add(T entity, bool persist = true);
        int AddRange(IEnumerable<T> entities, bool persist = true);
        int Update(T entity, bool persist = true);
        int UpdateRange(IEnumerable<T> entities, bool persist = true);
        int Delete(int id, byte[] timeStamp, bool persist = true);
        int Delete(T entity, bool persist = true);
        int DeleteRange(IEnumerable<T> entities, bool persist = true);
        T Find(int? id);
        T FindAsNoTracking(int id);
        T FindIgnoreQueryFilters(int id);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, object>> orderBy);
        public IEnumerable<T> GetRange(IQueryable<T> query, int skip, int take);

        void ExecuteQuery(string sql, object[] sqlParametersObjects);
        int SaveChanges();
    }
}