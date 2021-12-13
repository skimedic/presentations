namespace AutoLot.Services.DataServices.Dal.Base;

public abstract class DalDataServiceBase<TEntity, TDataService> : IDataServiceBase<TEntity> 
    where TEntity : BaseEntity, new()
    where TDataService : class
{
    protected readonly IBaseRepo<TEntity> MainRepo;
    protected readonly IAppLogging<TDataService> AppLoggingInstance;

    protected DalDataServiceBase(IAppLogging<TDataService> appLogging, IBaseRepo<TEntity> mainRepo)
    {
        MainRepo = mainRepo;
        AppLoggingInstance = appLogging;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() 
        => MainRepo.GetAllIgnoreQueryFilters();

    public async Task<TEntity> FindAsync(int id) => MainRepo.Find(id);

    public async Task<TEntity> UpdateAsync(TEntity entity, bool persist = true)
    {
        MainRepo.Update(entity, persist);
        return entity;
    }

    public async Task DeleteAsync(TEntity entity, bool persist = true) 
        => MainRepo.Delete(entity, persist);

    public async Task<TEntity> AddAsync(TEntity entity, bool persist = true)
    {
        MainRepo.Add(entity, persist);
        return entity;
    }

    public void ResetChangeTracker()
    {
        MainRepo.Context.ChangeTracker.Clear();
    }
}