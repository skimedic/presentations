// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal.Tests - BaseTest.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Dal.Tests.Base;

public abstract class BaseTest : IDisposable
{
    protected readonly IConfiguration Configuration;
    protected readonly ApplicationDbContext Context;
    protected readonly ITestOutputHelper OutputHelper;


    protected BaseTest(ITestOutputHelper outputHelper)
    {
        Configuration = TestHelpers.GetConfiguration();
        Context = TestHelpers.GetContext(Configuration);
        OutputHelper = outputHelper;
    }

    public virtual void Dispose()
    {
        Context.Dispose();
    }

    protected void ExecuteInATransaction(Action actionToExecute)
    {
        var strategy = Context.Database.CreateExecutionStrategy();
        strategy.Execute(() =>
        {
            using var trans = Context.Database.BeginTransaction();
            actionToExecute();
            trans.Rollback();
        });
    }

    protected void ExecuteInASharedTransaction(Action<IDbContextTransaction> actionToExecute)
    {
        var strategy = Context.Database.CreateExecutionStrategy();
        strategy.Execute(() =>
        {
            using IDbContextTransaction trans = Context.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
            actionToExecute(trans);
            trans.Rollback();
        });
    }
}