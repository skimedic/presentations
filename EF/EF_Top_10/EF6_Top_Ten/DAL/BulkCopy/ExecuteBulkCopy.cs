#region copyright
// // Copyright Information
// // ==============================
// // DAL - ExecuteBulkCopy.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Models;
using DAL.Repos;

namespace DAL.BulkCopy
{
    public static class ExecuteBulkCopy
    {
        public static void ImportRecordsToSQL(List<AccountTransaction> records)
        {
            var db = new StoreContext();
            var connString = db.Database.Connection.ConnectionString;


            SqlBulkCopy bc = null;
            bc = new SqlBulkCopy(connString)
            {
                DestinationTableName = new AccountTransactionRepo().GetTableName()
            };
            var dataReader = new AccountTransactionDataReader(records);
            bc.WriteToServer(dataReader);
        }
    }
}
