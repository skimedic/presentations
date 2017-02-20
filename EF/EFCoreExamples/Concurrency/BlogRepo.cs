using System;
using System.Linq;
using Concurrency.Context;
using Concurrency.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Concurrency
{
    public class BlogRepo : IDisposable
    {
        private readonly BloggingContext _bloggingContext = new BloggingContext();
        public DbSet<Blog> Table;
        public BlogRepo()
        {
            Table = _bloggingContext.Set<Blog>();
        }

        public Blog GetFirst()
        {
            return Table.FirstOrDefault();
        }
        public int Add(Blog entity)
        {
            Table.Add(entity);
            return SaveChanges();
        }
        public int Update(Blog entity)
        {
            Table.Update(entity);
            return SaveChanges();
        }

        public int SaveChanges()
        {
            try
            {
                return _bloggingContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //A concurrency error occurred
                //Should handle intelligently
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                //Should handle intelligently
                Console.WriteLine(ex);
                throw;
            }

        }

        public void Dispose()
        {
            _bloggingContext?.Dispose();
        }
    }
}
