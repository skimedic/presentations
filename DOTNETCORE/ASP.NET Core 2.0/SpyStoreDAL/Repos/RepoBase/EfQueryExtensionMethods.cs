using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SpyStoreModels.Models.Base;

namespace SpyStoreDAL.Repos.RepoBase
{
    public static class EfQueryExtensionMethods
    {
        public static IQueryable<T> TakeRange<T>(this IQueryable<T> query, int skip = 0, int take = 0)
        {
            if (skip != 0)
            {
                query = query.Skip(skip);
            }
            if (take != 0)
            {
                query = query.Take(take);
            }
            return query;
        }
        public static IQueryable<T> AddWheres<T>(
            this DbSet<T> query, params Expression<Func<T, bool>>[] wheres) where T : EntityBase, new()
        {
            switch (wheres.Length)
            {
                case 0:
                    return query;
                case 1:
                    return query.Where(wheres[0]);
                default:
                    return query.Where(wheres[0]).AddWheres(wheres.Skip(1).ToArray());
            }
        }

        public static IQueryable<T> AddWheres<T>(
            this IQueryable<T> query, params Expression<Func<T, bool>>[] wheres) where T : EntityBase, new()
        {
            return wheres.Aggregate(query, (current, espression) => current.Where(espression));
        }

        public static IQueryable<T> AddIncludes<T>(
            this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T:EntityBase,new()
        {
            foreach (var espression in includes)
            {
                query = query.Include(espression);
            }
            return query;
        }
        public static IQueryable<T> AddOrderBys<T>(
            this DbSet<T> query, params (Expression<Func<T, object>>, bool)[] orderBys) where T : EntityBase, new()
        {
            switch (orderBys.Length)
            {
                case 0:
                    return query;
                case 1:
                    return orderBys[0].Item2
                        ? query.OrderBy(orderBys[0].Item1)
                        : query.OrderByDescending(orderBys[0].Item1);
                default:
                    return orderBys[0].Item2
                        ? query.OrderBy(orderBys[0].Item1).AddOrderBys(orderBys.Skip(1).ToArray())
                        : query.OrderByDescending(orderBys[0].Item1).AddOrderBys(orderBys.Skip(1).ToArray());
            }
        }

        public static IQueryable<T> AddOrderBys<T>(
            this IQueryable<T> query, params (Expression<Func<T, object>>, bool)[] orderBys) where T : EntityBase, new()
        {
            foreach (var itm in orderBys)
            {
                if (!query.IsOrdered())
                {
                    query = itm.Item2 ? query.OrderBy(itm.Item1) : query.OrderByDescending(itm.Item1);
                }
                else
                {
                    query = itm.Item2 ? ((IOrderedQueryable<T>)query).ThenBy(itm.Item1) : ((IOrderedQueryable<T>)query).ThenByDescending(itm.Item1);

                }
            }
            return query;
        }
        public static bool IsOrdered<T>(this IQueryable<T> query)
        {
            return query.Expression.Type == typeof(IOrderedQueryable<T>);
        }

    }
}