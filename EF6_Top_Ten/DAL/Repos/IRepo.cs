#region copyright
// // Copyright Information
// // ==============================
// // DAL - IRepo.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repos
{
	interface IRepo<T>
	{
		T GetOne(int? id);
		Task<T> GetOneAsync(int? id);
		List<T> GetAll();
		Task<List<T>> GetAllAsync();
		int Save(T entity);
		Task<int> SaveAsync(T entity);
		int Add(T entity);
		Task<int> AddAsync(T entity);
		int AddRange(IEnumerable<T> entities);
		Task<int> AddRangeAsync(IEnumerable<T> entities);
		int Delete(T entity);
		Task<int> DeleteAsync(T entity);
	}
}
