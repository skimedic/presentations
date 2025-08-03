// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Dal - SampleData.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/03
// ==================================

namespace AutoLot.Dal.Initialization;

public static class SampleData
{
    public static List<Make> Makes =>
    [
        new() { Id = 1, Name = "VW" },
        new() { Id = 2, Name = "Ford" },
        new() { Id = 3, Name = "Saab" },
        new() { Id = 4, Name = "Yugo" },
        new() { Id = 5, Name = "BMW" },
        new() { Id = 6, Name = "Pinto" }
    ];

    public static List<Driver> Drivers =>
    [
        new() { Id = 1, PersonInformation = new() { FirstName = "Fred", LastName = "Flintstone" } },
        new() { Id = 2, PersonInformation = new() { FirstName = "Barney", LastName = "Rubble" } }
    ];

    public static List<Car> Inventory =>
    [
        new() { Id = 1, MakeId = 1, Color = "Black", PetName = "Zippy", Price = "50000" },
        new() { Id = 2, MakeId = 2, Color = "Rust", PetName = "Rusty", Price = "50000" },
        new() { Id = 3, MakeId = 3, Color = "Black", PetName = "Mel", Price = "50000" },
        new() { Id = 4, MakeId = 4, Color = "Yellow", PetName = "Clunker", Price = "50000" },
        new() { Id = 5, MakeId = 5, Color = "Black", PetName = "Bimmer", Price = "50000" },
        new() { Id = 6, MakeId = 5, Color = "Green", PetName = "Hank", Price = "50000" },
        new() { Id = 7, MakeId = 5, Color = "Pink", PetName = "Pinky", Price = "50000" },
        new() { Id = 8, MakeId = 6, Color = "Black", PetName = "Pete", Price = "50000" },
        new() { Id = 9, MakeId = 4, Color = "Brown", PetName = "Brownie", Price = "50000" },
        new() { Id = 10, MakeId = 1, Color = "Rust", PetName = "Lemon", IsDrivable = false, Price = "50000" }
    ];

    public static List<CarDriver> CarsAndDrivers =>
    [
        new() { Id = 1, CarId = 1, DriverId = 1 },
        new() { Id = 2, CarId = 2, DriverId = 2 }
    ];

    public static List<Radio> Radios =>
    [
        new() { Id = 1, CarId = 1, HasSubWoofers = true, RadioId = "SuperRadio 1", HasTweeters = true },
        new() { Id = 2, CarId = 2, HasSubWoofers = true, RadioId = "SuperRadio 2", HasTweeters = true },
        new() { Id = 3, CarId = 3, HasSubWoofers = true, RadioId = "SuperRadio 3", HasTweeters = true },
        new() { Id = 4, CarId = 4, HasSubWoofers = true, RadioId = "SuperRadio 4", HasTweeters = true },
        new() { Id = 5, CarId = 5, HasSubWoofers = true, RadioId = "SuperRadio 5", HasTweeters = true },
        new() { Id = 6, CarId = 6, HasSubWoofers = true, RadioId = "SuperRadio 6", HasTweeters = true },
        new() { Id = 7, CarId = 7, HasSubWoofers = true, RadioId = "SuperRadio 7", HasTweeters = true },
        new() { Id = 8, CarId = 8, HasSubWoofers = true, RadioId = "SuperRadio 8", HasTweeters = true },
        new() { Id = 9, CarId = 9, HasSubWoofers = true, RadioId = "SuperRadio 9", HasTweeters = true },
        new() { Id = 10, CarId = 10, HasSubWoofers = true, RadioId = "SuperRadio 10", HasTweeters = true }
    ];

}
