#region Copyright
// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Mvc - CartViewModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 02/24/2019
// See License.txt for more information
// ==================================
#endregion

using System.Collections.Generic;
using SpyStore.Models.Entities;

namespace SpyStore.Hol.Mvc.Models.ViewModels
{
    public class CartViewModel
    {
        public Customer Customer { get; set; }
        public IList<CartRecordViewModel> CartRecords { get; set; }
    }
}