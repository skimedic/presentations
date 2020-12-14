// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal.Tests - CarTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.Collections.Generic;
using System.Linq;
using AutoLot.Dal.Exceptions;
using AutoLot.Models.Entities;
using AutoLot.Dal.Tests.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Xunit;

namespace AutoLot.Dal.Tests.ContextTests
{
    [Collection("Integration Tests")]
    public class CarTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTestFixture>
    {
        [Fact]
        public void ShouldReturnNoCarsWithQueryFilterNotSet()
        {
            var cars = Context.Cars.ToList();
            Assert.Empty(cars);
        }

        [Fact]
        public void ShouldGetAllOfTheCars()
        {
            var cars = Context.Cars.IgnoreQueryFilters().ToList();
            Assert.Equal(9, cars.Count);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 1)]
        public void ShouldGetTheCarsByMake(int makeId, int expectedCount)
        {
            Context.MakeId = makeId;
            var cars = Context.Cars.ToList();
            Assert.Equal(expectedCount, cars.Count);
        }

        [Fact]
        public void ShouldNotGetTheCarsUsingFromSql()
        {
            var entity = Context.Model.FindEntityType($"{typeof(Car).FullName}");
            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
            var cars = Context.Cars.FromSqlRaw($"Select * from {schemaName}.{tableName}").ToList();
            Assert.Empty(cars);
        }

        [Fact]
        public void ShouldGetTheCarsUsingFromSqlWithIgnoreQueryFilters()
        {
            var entity = Context.Model.FindEntityType($"{typeof(Car).FullName}");
            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
            var cars = Context.Cars.FromSqlRaw($"Select * from {schemaName}.{tableName}").IgnoreQueryFilters().ToList();
            Assert.Equal(9, cars.Count);
        }

        [Fact]
        public void ShouldGetOneCarUsingInterpolation()
        {
            var carId = 1;
            var car = Context.Cars
                .FromSqlInterpolated($"Select * from dbo.Inventory where Id = {carId}")
                .Include(x => x.MakeNavigation)
                .IgnoreQueryFilters().First();
            Assert.Equal("Black", car.Color);
            Assert.Equal("VW", car.MakeNavigation.Name);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 1)]
        public void ShouldGetTheCarsByMakeUsingFromSql(int makeId, int expectedCount)
        {
            Context.MakeId = makeId;
            var entity = Context.Model.FindEntityType($"{typeof(Car).FullName}");
            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
            var cars = Context.Cars.FromSqlRaw($"Select * from {schemaName}.{tableName}").ToList();
            Assert.Equal(expectedCount, cars.Count);
        }

        [Fact]
        public void ShouldGetAllOfTheCarsWithMakes()
        {
            var cars = Context.Cars.IgnoreQueryFilters().Include(c => c.MakeNavigation).ToList();
            Assert.Equal(9, cars.Count);
        }

        [Fact]
        public void ShouldGetCarsOnOrderWithRelatedProperties()
        {
            var cars = Context.Cars.IgnoreQueryFilters().Where(c => c.Orders.Any())
                .Include(c => c.MakeNavigation)
                .Include(c => c.Orders).ThenInclude(o => o.CustomerNavigation).ToList();
            Assert.Equal(4, cars.Count);
            cars.ForEach(c =>
            {
                Assert.NotNull(c.MakeNavigation);
                Assert.NotNull(c.Orders.ToList()[0].CustomerNavigation);
            });
        }

        [Fact]
        public void ShouldGetRelatedInformationExplicitly()
        {
            var car = Context.Cars.IgnoreQueryFilters().First(x => x.Id == 1);
            Assert.Null(car.MakeNavigation);
            Context.Entry(car).Reference(c => c.MakeNavigation).Load();
            Assert.NotNull(car.MakeNavigation);

            Assert.Empty(car.Orders);
            Context.Entry(car).Collection(c => c.Orders).Query().IgnoreQueryFilters().Load();
            Assert.Single(car.Orders);
        }

        [Fact]
        public void ShouldAddACar()
        {
            ExecuteInATransaction(RunTheTest);

            void RunTheTest()
            {
                var car = new Car
                {
                    Color = "Yellow",
                    MakeId = 1,
                    PetName = "Herbie"
                };
                var carCount = Context.Cars.IgnoreQueryFilters().Count();
                Context.Cars.Add(car);
                Context.SaveChanges();
                var newCarCount = Context.Cars.IgnoreQueryFilters().Count();
                Assert.Equal(carCount + 1, newCarCount);
            }
        }

        [Fact]
        public void ShouldAddMultipleCars()
        {
            ExecuteInATransaction(RunTheTest);

            void RunTheTest()
            {
                var cars = new List<Car>
                {
                    new Car
                    {
                        Color = "Yellow",
                        MakeId = 1,
                        PetName = "Herbie"
                    },
                    new Car
                    {
                        Color = "White",
                        MakeId = 2,
                        PetName = "Mach 5"
                    },
                };
                var carCount = Context.Cars.IgnoreQueryFilters().Count();
                Context.Cars.AddRange(cars);
                Context.SaveChanges();
                var newCarCount = Context.Cars.IgnoreQueryFilters().Count();
                Assert.Equal(carCount + 2, newCarCount);
            }
        }

        [Fact]
        public void ShouldAddAnObjectGraph()
        {
            ExecuteInATransaction(RunTheTest);

            void RunTheTest()
            {
                var make = new Make { Name = "Honda" };
                var car = new Car
                {
                    Color = "Yellow",
                    MakeId = 1,
                    PetName = "Herbie"
                };
                ((List<Car>)make.Cars).Add(car);
                Context.Makes.Add(make);
                var carCount = Context.Cars.IgnoreQueryFilters().Count();
                var makeCount = Context.Makes.IgnoreQueryFilters().Count();
                Context.SaveChanges();
                var newCarCount = Context.Cars.IgnoreQueryFilters().Count();
                var newMakeCount = Context.Makes.IgnoreQueryFilters().Count();
                Assert.Equal(carCount + 1, newCarCount);
                Assert.Equal(makeCount + 1, newMakeCount);

            }
        }
        [Fact]
        public void ShouldUpdateACar()
        {
            ExecuteInASharedTransaction(RunTheTest);

            void RunTheTest(IDbContextTransaction trans)
            {
                var car = Context.Cars.IgnoreQueryFilters().First(c => c.Id == 1);
                Assert.Equal("Black", car.Color);
                car.Color = "White";
                Context.SaveChanges();
                Assert.Equal("White", car.Color);
                var context2 = TestHelpers.GetSecondContext(Context, trans);
                var car2 = context2.Cars.IgnoreQueryFilters().First(c => c.Id == 1);
                Assert.Equal("White", car2.Color);
            }
        }
        [Fact]
        public void ShouldUpdateACarUsingState()
        {
            ExecuteInASharedTransaction(RunTheTest);

            void RunTheTest(IDbContextTransaction trans)
            {
                var car = Context.Cars.IgnoreQueryFilters().AsNoTracking().First(c => c.Id == 1);
                Assert.Equal("Black", car.Color);
                var updatedCar = new Car
                {
                    Color = "White", //Original is Black
                    Id = car.Id,
                    MakeId = car.MakeId,
                    PetName = car.PetName,
                    TimeStamp = car.TimeStamp
                };
                var context2 = TestHelpers.GetSecondContext(Context, trans);
                context2.Entry(updatedCar).State = EntityState.Modified;
                //context2.Cars.Update(updatedCar);
                context2.SaveChanges();
                var context3 = TestHelpers.GetSecondContext(Context, trans);
                var car2 = context3.Cars.IgnoreQueryFilters().First(c => c.Id == 1);
                Assert.Equal("White", car2.Color);
            }
        }

        [Fact]
        public void ShouldThrowConcurrencyException()
        {
            ExecuteInATransaction(RunTheTest);

            void RunTheTest()
            {
                var car = Context.Cars.IgnoreQueryFilters().First();
                //Update the database outside of the context
                Context.Database.ExecuteSqlInterpolated($"Update dbo.Inventory set Color='Pink' where Id = {car.Id}");
                car.Color = "Yellow";
                var ex = Assert.Throws<CustomConcurrencyException>(() => Context.SaveChanges());
                var entry = ((DbUpdateConcurrencyException)ex.InnerException)?.Entries[0];
                PropertyValues originalProps = entry.OriginalValues;
                PropertyValues currentProps = entry.CurrentValues;
                //This needs another database call
                PropertyValues databaseProps = entry.GetDatabaseValues();
            }
        }

        [Fact]
        public void ShouldRemoveACar()
        {
            ExecuteInATransaction(RunTheTest);

            void RunTheTest()
            {
                var carCount = Context.Cars.IgnoreQueryFilters().Count();
                var car = Context.Cars.IgnoreQueryFilters().First(c => c.Id == 2);
                Context.Cars.Remove(car);
                Context.SaveChanges();
                var newCarCount = Context.Cars.IgnoreQueryFilters().Count();
                Assert.Equal(carCount - 1, newCarCount);
                Assert.Equal(EntityState.Detached,Context.Entry(car).State);
            }
        }

        [Fact]
        public void ShouldFailToRemoveACar()
        {
            ExecuteInATransaction(RunTheTest);

            void RunTheTest()
            {
                var car = Context.Cars.IgnoreQueryFilters().First(c => c.Id == 1);
                Context.Cars.Remove(car);
                Assert.Throws<CustomDbUpdateException>(()=>Context.SaveChanges());
            }
        }

        [Fact]
        public void ShouldRemoveACarUsingState()
        {
            ExecuteInASharedTransaction(RunTheTest);

            void RunTheTest(IDbContextTransaction trans)
            {
                var carCount = Context.Cars.IgnoreQueryFilters().Count();
                var car = Context.Cars.IgnoreQueryFilters().AsNoTracking().First(c => c.Id == 2);
                var context2 = TestHelpers.GetSecondContext(Context, trans);
                //context2.Entry(car).State = EntityState.Deleted;
                context2.Cars.Remove(car);
                context2.SaveChanges();
                var newCarCount = Context.Cars.IgnoreQueryFilters().Count();
                Assert.Equal(carCount - 1, newCarCount);
                Assert.Equal(EntityState.Detached, Context.Entry(car).State);
            }
        }
    }
}