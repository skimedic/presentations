using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SpyStoreModels.ViewModels.Base;

namespace SpyStore_v21.Models.CustomViewModels.Base
{
    public class CartViewModelBase : ProductAndCategoryBase
    {
        public int? CustomerId { get; set; }
        [DataType(DataType.Currency), Display(Name = "Total")]
        public decimal LineItemTotal { get; set; }

        public string TimeStampString => 
           TimeStamp != null ? JsonConvert.SerializeObject(TimeStamp).Replace("\"",""):string.Empty;
    }
}