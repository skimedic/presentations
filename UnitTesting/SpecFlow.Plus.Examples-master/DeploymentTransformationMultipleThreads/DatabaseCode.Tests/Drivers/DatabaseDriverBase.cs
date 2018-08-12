using DatabaseCode.Tests.Support;

namespace DatabaseCode.Tests.Drivers
{
    public abstract class DatabaseDriverBase
    {
        protected DatabaseDriverBase(DatabaseContextWrapper dbContext, DriverPersonState state)
        {
            DbContext = dbContext;
            State = state;
        }

        protected DatabaseContextWrapper DbContext { get; }

        protected DriverPersonState State { get; }
    }
}
