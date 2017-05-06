using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace SpyStore_HOL.DAL.EF
{
    public class MyExecutionStrategy : ExecutionStrategy
    {
        public MyExecutionStrategy(ExecutionStrategyContext context) :
            base(context, ExecutionStrategy.DefaultMaxRetryCount, ExecutionStrategy.DefaultMaxDelay)
        {
        }

        public MyExecutionStrategy(ExecutionStrategyContext context, int maxRetryCount, TimeSpan maxRetryDelay) : base(context, maxRetryCount, maxRetryDelay)
        {
        }

        protected override bool ShouldRetryOn(Exception exception)
        {
            return true;
        }
    }
}
