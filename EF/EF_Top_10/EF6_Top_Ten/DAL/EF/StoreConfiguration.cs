#region copyright
// // Copyright Information
// // ==============================
// // DAL - StoreConfiguration.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace DAL.EF
{
    public class StoreConfiguration : DbConfiguration
    {
        //automatically used if in the same assembly as your context
        public StoreConfiguration()
        {
            //SetExecutionStrategy("System.Data.SqlClient",
            //     () => new SqlAzureExecutionStrategy(3, TimeSpan.FromMilliseconds(10)));
            SetExecutionStrategy("System.Data.SqlClient",
                () => new StoreExecutionStrategy(1, TimeSpan.FromMilliseconds(10)));
        }

    }
}