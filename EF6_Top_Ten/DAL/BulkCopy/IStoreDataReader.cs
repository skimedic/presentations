#region copyright
// // Copyright Information
// // ==============================
// // DAL - IStoreDataReader.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BulkCopy
{
    public interface IStoreDataReader<T>
    {
        List<T> Records { get; set; }
    }
}
