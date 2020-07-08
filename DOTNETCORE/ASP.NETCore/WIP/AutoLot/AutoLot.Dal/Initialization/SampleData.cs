using System.Collections.Generic;
using AutoLot.Dal.Models.Entities;
using AutoLot.Dal.Models.Entities.Owned;

namespace AutoLot.Dal.Initialization
{
    public static class SampleData
    {
        public static List<Customer> Customers =>
            new List<Customer>
            {
                new Customer {Id = 1, PersonalInformation = new Person{FirstName = "Dave", LastName = "Brenner"}},
                new Customer {Id = 2, PersonalInformation = new Person{FirstName = "Matt", LastName = "Walton"}},
                new Customer {Id = 3, PersonalInformation = new Person{FirstName = "Steve", LastName = "Hagen"}},
                new Customer {Id = 4, PersonalInformation = new Person{FirstName = "Pat", LastName = "Walton"}},
                new Customer {Id = 5, PersonalInformation = new Person{FirstName = "Bad", LastName = "Customer"}},
            };

        public static List<Make> Makes => new List<Make>
        {
            new Make {Id = 1, Name = "VW"},
            new Make {Id = 2, Name = "Ford"},
            new Make {Id = 3, Name = "Saab"},
            new Make {Id = 4, Name = "Yugo"},
            new Make {Id = 5, Name = "BMW"},
            new Make {Id = 6, Name = "Pinto"},
        };
        public static List<Car> Inventory => new List<Car>
        {
            new Car {Id = 1, MakeId = 1, Color = "Black", PetName = "Zippy"},
            new Car {Id = 2, MakeId = 2, Color = "Rust", PetName = "Rusty"},
            new Car {Id = 3, MakeId = 3, Color = "Black", PetName = "Mel"},
            new Car {Id = 4, MakeId = 4, Color = "Yellow", PetName = "Clunker"},
            new Car {Id = 5, MakeId = 5, Color = "Black", PetName = "Bimmer"},
            new Car {Id = 6, MakeId = 5, Color = "Green", PetName = "Hank"},
            new Car {Id = 7, MakeId = 5, Color = "Pink", PetName = "Pinky"},
            new Car {Id = 8, MakeId = 6, Color = "Black", PetName = "Pete"},
            new Car {Id = 9, MakeId = 4, Color = "Brown", PetName = "Brownie"},
        };

        public static List<Order> Orders => new List<Order>
        {
            new Order {Id = 1, CustomerId = 1, CarId = 5},
            new Order {Id = 2, CustomerId = 2, CarId = 1},
            new Order {Id = 3, CustomerId = 3, CarId = 4},
            new Order {Id = 4, CustomerId = 4, CarId = 7},
        };

        public static List<CreditRisk> CreditRisks => new List<CreditRisk>
        {
            new CreditRisk
            {
                Id = 1,
                CustomerId = Customers[4].Id,
                PersonalInformation = new Person{
                    FirstName = Customers[4].PersonalInformation.FirstName,
                LastName = Customers[4].PersonalInformation.LastName
                }
            }
        };
    }
}