// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal.Tests - EnsureAutoLotDatabaseTestFixture.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System;
using AutoLot.Dal.Initialization;

namespace AutoLot.Dal.Tests.Base
{
    public sealed class EnsureAutoLotDatabaseTestFixture : IDisposable
    {
        public EnsureAutoLotDatabaseTestFixture()
        {
            var configuration =  TestHelpers.GetConfiguration();
            var context = TestHelpers.GetContext(configuration);
            SampleDataInitializer.ClearAndReseedDatabase(context);
            context.Dispose();
        }

        public void Dispose()
        {
        }
    }
}