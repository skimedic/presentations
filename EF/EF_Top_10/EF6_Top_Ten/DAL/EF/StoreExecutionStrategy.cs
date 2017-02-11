#region copyright
// // Copyright Information
// // ==============================
// // DAL - StoreExecutionStrategy.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Exceptions;

namespace DAL.EF
{
    public class StoreExecutionStrategy : DbExecutionStrategy
    {
        public StoreExecutionStrategy() :
            base()
        {
        }

        public StoreExecutionStrategy(int maxRetryCount, TimeSpan maxDelay) :
            base(maxRetryCount, maxDelay)
        {
        }

        protected override bool ShouldRetryOn(Exception ex)
        {
            //Check for some other exception
            if (ex is SqlException) return true;
            return false;
            //return ex is TimeoutException;

            //This is the implementation in SqlAzureExecutionStrategy
            //protected override bool ShouldRetryOn(Exception exception)
            //{
            //      return SqlAzureRetriableExceptionDetector.ShouldRetryOn(exception);
            //}

        }
    }
}
