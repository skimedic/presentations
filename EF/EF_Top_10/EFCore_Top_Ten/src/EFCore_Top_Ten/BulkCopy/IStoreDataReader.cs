#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - IStoreDataReader.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.Collections.Generic;

namespace EFCore_Top_Ten.BulkCopy
{
    public interface IStoreDataReader<T>
    {
        List<T> Records { get; set; }
    }
}
