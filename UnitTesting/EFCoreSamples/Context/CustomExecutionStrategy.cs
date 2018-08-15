using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace EFCoreSamples.Context
{
    public class CustomExecutionStrategy : ExecutionStrategy
    {
        public CustomExecutionStrategy(ExecutionStrategyDependencies strategy) :
            base(strategy, ExecutionStrategy.DefaultMaxRetryCount, ExecutionStrategy.DefaultMaxDelay)
        {
        }

        public CustomExecutionStrategy(ExecutionStrategyDependencies strategy, int maxRetryCount, TimeSpan maxRetryDelay) 
            : base(strategy, maxRetryCount, maxRetryDelay)
        {
        }

        protected override bool ShouldRetryOn(Exception exception)
        {
            //Add in the specific exceptions that warrant a retry
            return true;
        }
    }
}
