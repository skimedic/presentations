// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Dal.Tests - EnsureAutoLotDatabaseTestFixture.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/02
// ==================================

namespace AutoLot.Dal.Tests.Base;

public sealed class EnsureAutoLotDatabaseTestFixture : IDisposable
{
    public EnsureAutoLotDatabaseTestFixture()
    {
        var configuration = TestHelpers.GetConfiguration();
        var context = TestHelpers.GetContext(configuration);
        SampleDataInitializer.ClearAndReseedDatabase(context);
        context.Dispose();
    }

    public void Dispose()
    {
    }
}
