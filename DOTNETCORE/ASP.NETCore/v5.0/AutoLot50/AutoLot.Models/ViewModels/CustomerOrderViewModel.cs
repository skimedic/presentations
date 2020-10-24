// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - CustomerOrderViewModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/08/08
// See License.txt for more information
// ==================================

using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLot.Models.ViewModels
{
    public class CustomerOrderViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Color { get; set; }
        public string? PetName { get; set; }
        public string? Make { get; set; }

        [NotMapped] public string FullDetail => $"{FirstName} {LastName} ordered a {Color} {Make} named {PetName}";

        public override string ToString() => FullDetail;
    }
}