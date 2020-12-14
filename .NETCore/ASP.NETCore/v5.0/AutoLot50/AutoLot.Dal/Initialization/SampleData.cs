// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - SampleData.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.Collections.Generic;
using AutoLot.Models.Entities;
using AutoLot.Models.Entities.Owned;

namespace AutoLot.Dal.Initialization
{
    public static class SampleData
    {
        public static List<Customer> Customers => new()
            {
                new() {Id = 1, PersonalInformation = new Person {FirstName = "Dave", LastName = "Brenner"}},
                new() {Id = 2, PersonalInformation = new Person {FirstName = "Matt", LastName = "Walton"}},
                new() {Id = 3, PersonalInformation = new Person {FirstName = "Steve", LastName = "Hagen"}},
                new() {Id = 4, PersonalInformation = new Person {FirstName = "Pat", LastName = "Walton"}},
                new() {Id = 5, PersonalInformation = new Person {FirstName = "Bad", LastName = "Customer"}},
            };

        public static List<Make> Makes => new()
        {
            new() {Id = 1, Name = "VW"},
            new() {Id = 2, Name = "Ford"},
            new() {Id = 3, Name = "Saab"},
            new() {Id = 4, Name = "Yugo"},
            new() {Id = 5, Name = "BMW"},
            new() {Id = 6, Name = "Pinto"},
        };

        public static List<Car> Inventory => new()
        {
            new() {Id = 1, MakeId = 1, Color = "Black", PetName = "Zippy"},
            new() {Id = 2, MakeId = 2, Color = "Rust", PetName = "Rusty"},
            new() {Id = 3, MakeId = 3, Color = "Black", PetName = "Mel"},
            new() {Id = 4, MakeId = 4, Color = "Yellow", PetName = "Clunker"},
            new() {Id = 5, MakeId = 5, Color = "Black", PetName = "Bimmer"},
            new() {Id = 6, MakeId = 5, Color = "Green", PetName = "Hank"},
            new() {Id = 7, MakeId = 5, Color = "Pink", PetName = "Pinky"},
            new() {Id = 8, MakeId = 6, Color = "Black", PetName = "Pete"},
            new() {Id = 9, MakeId = 4, Color = "Brown", PetName = "Brownie"},
        };

        public static List<Order> Orders => new()
        {
            new() {Id = 1, CustomerId = 1, CarId = 5},
            new() {Id = 2, CustomerId = 2, CarId = 1},
            new() {Id = 3, CustomerId = 3, CarId = 4},
            new() {Id = 4, CustomerId = 4, CarId = 7},
        };

        public static List<CreditRisk> CreditRisks => new()
        {
            new()
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