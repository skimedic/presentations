// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal - BaseRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/10
// ==================================

namespace AutoLot.Dal.Repos.Base;

public abstract class BaseRepo<T> : BaseViewRepo<T>, IBaseRepo<T> where T : BaseEntity, new()
{
    protected BaseRepo(ApplicationDbContext context) : base(context) { }

    protected BaseRepo(DbContextOptions<ApplicationDbContext> options) : this(new ApplicationDbContext(options))
    {
    }

    public virtual T Find(int? id)
        => Table.Find(id);

    public virtual T FindAsNoTracking(int id)
        => Table.AsNoTrackingWithIdentityResolution().FirstOrDefault(x => x.Id == id);

    public virtual T FindIgnoreQueryFilters(int id)
        => Table.IgnoreQueryFilters().FirstOrDefault(x => x.Id == id);

    public virtual void ExecuteParameterizedQuery(string sql, object[] sqlParametersObjects)
        => Context.Database.ExecuteSqlRaw(sql, sqlParametersObjects);

    public virtual int Add(T entity, bool persist = true)
    {
        Table.Add(entity);
        return persist ? SaveChanges() : 0;
    }

    public virtual int AddRange(IEnumerable<T> entities, bool persist = true)
    {
        Table.AddRange(entities);
        return persist ? SaveChanges() : 0;
    }

    public virtual int Update(T entity, bool persist = true)
    {
        Table.Update(entity);
        return persist ? SaveChanges() : 0;
    }

    public virtual int UpdateRange(IEnumerable<T> entities, bool persist = true)
    {
        Table.UpdateRange(entities);
        return persist ? SaveChanges() : 0;
    }

    public int Delete(int id, byte[] timeStamp, bool persist = true)
    {
        var entity = new T { Id = id, TimeStamp = timeStamp };
        Context.Entry(entity).State = EntityState.Deleted;
        return persist ? SaveChanges() : 0;
    }

    public virtual int Delete(T entity, bool persist = true)
    {
        Table.Remove(entity);
        return persist ? SaveChanges() : 0;
    }

    public virtual int DeleteRange(IEnumerable<T> entities, bool persist = true)
    {
        Table.RemoveRange(entities);
        return persist ? SaveChanges() : 0;
    }

    public int SaveChanges()
    {
        try
        {
            return Context.SaveChanges();
        }
        catch (CustomException ex)
        {
            //Should handle intelligently - already logged
            throw;
        }
        catch (Exception ex)
        {
            //Should log and handle intelligently
            throw new CustomException("An error occurred updating the database", ex);
        }
    }
}