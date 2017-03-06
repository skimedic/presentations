using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace ConnectionResiliency.Context
{
    public class CustomExecutionStrategy : ExecutionStrategy
    {
        public CustomExecutionStrategy(ExecutionStrategyContext context) :
            base(context, ExecutionStrategy.DefaultMaxRetryCount, ExecutionStrategy.DefaultMaxDelay)
        {
        }

        public CustomExecutionStrategy(ExecutionStrategyContext context, int maxRetryCount, TimeSpan maxRetryDelay) 
            : base(context, maxRetryCount, maxRetryDelay)
        {
        }

        protected override bool ShouldRetryOn(Exception exception)
        {
            //Add in the specific exceptions that warrant a retry
            return true;
        }
    }
}
