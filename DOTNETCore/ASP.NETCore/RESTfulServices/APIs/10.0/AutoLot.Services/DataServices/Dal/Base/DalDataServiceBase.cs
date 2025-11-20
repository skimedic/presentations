// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - DalDataServiceBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/13
// ==================================

namespace AutoLot.Services.DataServices.Dal.Base;

public abstract class DalDataServiceBase<TEntity>(
    IAppLogging appLogging,
    IBaseRepo<TEntity> mainRepo) : IDataServiceBase<TEntity>
    where TEntity : BaseEntity, new()
{
    protected readonly IBaseRepo<TEntity> MainRepo = mainRepo;
    protected readonly IAppLogging AppLoggingInstance = appLogging;

    public Task<IEnumerable<TEntity>> GetAllAsync()
        => Task.FromResult(MainRepo.GetAllIgnoreQueryFilters());

    public Task<TEntity> FindAsync(int id) => Task.FromResult(MainRepo.Find(id));

    public Task<TEntity> UpdateAsync(TEntity entity, bool persist = true)
    {
        MainRepo.Update(entity, persist);
        return Task.FromResult(entity);
    }

    public Task DeleteAsync(TEntity entity, bool persist = true)
        => Task.FromResult(MainRepo.Delete(entity, persist));

    public Task<TEntity> AddAsync(TEntity entity, bool persist = true)
    {
        MainRepo.Add(entity, persist);
        return Task.FromResult(entity);
    }

    public void ResetChangeTracker()
    {
        MainRepo.Context.ChangeTracker.Clear();
    }
}