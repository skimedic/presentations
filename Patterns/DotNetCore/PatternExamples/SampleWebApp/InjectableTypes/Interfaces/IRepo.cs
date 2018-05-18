using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp.InjectableTypes.Interfaces
{
    public interface IRepo<T>
    {
        int Count { get; }
        T Find(int id);
        IList<T> GetAll();
        int Add(T entity, bool persist = true);
        int AddRange(IEnumerable<T> entities, bool persist = true);
        int Update(T entity, bool persist = true);
        int UpdateRange(IEnumerable<T> entities, bool persist = true);
        int Delete(T entity, bool persist = true);
        int DeleteRange(IEnumerable<T> entities, bool persist = true);
        int Delete(int id, byte[] timeStamp, bool persist = true);
        int SaveChanges();

    }
}
