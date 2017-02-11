#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - ExecuteBulkCopy.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using EFCore_Top_Ten.EF;
using EFCore_Top_Ten.Models;
using EFCore_Top_Ten.Repos;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Top_Ten.BulkCopy
{
    public static class ExecuteBulkCopy
    {
        public static void ImportRecordsToSQL(List<AccountTransaction> records)
        {
            var db = new StoreContext();
            var connString = db.Database.GetDbConnection().ConnectionString;


            SqlBulkCopy bc = null;
            bc = new SqlBulkCopy(connString)
            {
                DestinationTableName = AccountTransactionRepo.GetTableName(db)
            };
            var dataReader = new AccountTransactionDataReader(records);
            bc.WriteToServer(dataReader);
        }
    }
}
