using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.EF;

namespace AutoLotDAL.Repos
{
	public abstract class BaseRepo<T>: IDisposable where T:class,new()
	{
		public AutoLotEntities Context { get; } = new AutoLotEntities();
	    protected DbSet<T> Table;

        public T GetOne(int? id) => Table.Find(id);

        public async Task<T> GetOneAsync(int? id) => await Table.FindAsync(id);

        public List<T> GetAll() => Table.ToList();

        public Task<List<T>> GetAllAsync() => Table.ToListAsync();

        public int Add(T entity)
        {
            Table.Add(entity);
            return SaveChanges();
        }

        public async Task<int> AddAsync(T entity)
        {
            Table.Add(entity);
            return await SaveChangesAsync();
        }

        public int AddRange(IList<T> entities)
        {
            Table.AddRange(entities);
            return SaveChanges();
        }
        public Task<int> AddRangeAsync(IList<T> entities)
        {
            Table.AddRange(entities);
            return SaveChangesAsync();
        }

        public int AddRange(IEnumerable<T> entities)
        {
            Table.AddRange(entities);
            return SaveChanges();
        }

        public Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            Table.AddRange(entities);
            return SaveChangesAsync();
        }

        public int Save(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public async Task<int> SaveAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return await SaveChangesAsync();
        }

        public int Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return await SaveChangesAsync();
        }

        public List<T> ExecuteQuery(string sql) => Table.SqlQuery(sql).ToList();

        public Task<List<T>> ExecuteQueryAsync(string sql)
            => Table.SqlQuery(sql).ToListAsync();
        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
            => Table.SqlQuery(sql, sqlParametersObjects).ToList();
        public Task<List<T>> ExecuteQueryAsync(string sql, object[] sqlParametersObjects)
            => Table.SqlQuery(sql).ToListAsync();

        internal int SaveChanges()
		{
			try
			{
				return Context.SaveChanges();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				//Thrown when there is a concurrency error
				//If Entries propery is null, no records were modified
				//entities in Entries threw error due to timestamp/conncurrency
				//for now, just rethrow the exception
				throw;
			}
			catch (DbUpdateException ex)
			{
				//Thrown when database update fails
				//Examine the inner exception(s) for additional 
				//details and affected objects
				//for now, just rethrow the exception
				throw;
			}
			catch (CommitFailedException ex)
			{
				//handle transaction failures here
				//for now, just rethrow the exception
				throw;
			}
			catch (Exception ex)
			{
				//some other exception happened and should be handled
				throw;
			}
		}
		internal async Task<int> SaveChangesAsync()
		{
			try
			{
				return await Context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				//Thrown when there is a concurrency error
				//for now, just rethrow the exception
				throw;
			}
			catch (DbUpdateException ex)
			{
				//Thrown when database update fails
				//Examine the inner exception(s) for additional 
				//details and affected objects
				//for now, just rethrow the exception
				throw;
			}
			catch (CommitFailedException ex)
			{
				//handle transaction failures here
				//for now, just rethrow the exception
				throw;
			}
			catch (Exception ex)
			{
				//some other exception happened and should be handled
				throw;
			}
		}

		bool _disposed = false;
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			if (disposing)
			{
				Context.Dispose();
				// Free any managed objects here. 
				//
			}

			// Free any unmanaged objects here. 
			//
			_disposed = true;
		}
	}

}
