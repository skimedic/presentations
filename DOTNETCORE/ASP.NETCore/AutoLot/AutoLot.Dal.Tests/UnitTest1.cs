using System;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Initialization;
using Xunit;

namespace AutoLot.Dal.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldClearAndLoadTheDatabase()
        {
            var context = new ApplicationDbContextFactory().CreateDbContext(new string[0]);
            SampleDataInitializer.ClearDatabase(context);
        }
    }
}