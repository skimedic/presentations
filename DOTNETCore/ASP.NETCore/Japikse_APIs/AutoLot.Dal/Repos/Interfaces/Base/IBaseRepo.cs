// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - IBaseRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
// ==================================

namespace AutoLot.Dal.Repos.Interfaces.Base;

public interface IBaseRepo<T> : IBaseViewRepo<T> where T : BaseEntity, new()
{
    T Find(int? id);
    T FindAsNoTracking(int id);
    T FindIgnoreQueryFilters(int id);
    void ExecuteParameterizedQuery(string sql, object[] sqlParametersObjects);
    int Add(T entity, bool persist = true);
    int AddRange(IEnumerable<T> entities, bool persist = true);
    int Update(T entity, bool persist = true);
    int UpdateRange(IEnumerable<T> entities, bool persist = true);
    int Delete(int id, long timeStamp, bool persist = true);
    int Delete(T entity, bool persist = true);
    int DeleteRange(IEnumerable<T> entities, bool persist = true);
    int ExecuteBulkUpdate(Expression<Func<T, bool>> whereClause, 
        Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);
    int ExecuteBulkDelete(Expression<Func<T, bool>> whereClause);
    int SaveChanges();
}