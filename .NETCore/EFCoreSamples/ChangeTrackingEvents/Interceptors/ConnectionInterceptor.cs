using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ChangeTrackingEvents.Interceptors
{
    public class ConnectionInterceptor : DbConnectionInterceptor
    {
        public override void ConnectionOpened(DbConnection connection, ConnectionEndEventData eventData)
        {
            base.ConnectionOpened(connection, eventData);
        }
    }
}