using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BookShop.Mvc.Models
{
    public class ShoppingCart
    {
        private readonly List<OrderLine> _orderLines = new List<OrderLine>();

        [DisplayName("Total Price")]
        public decimal Price => _orderLines.Sum(li => li.Price);

        public int Count => _orderLines.Sum(li => li.Quantity);

        public IEnumerable<OrderLine> Lines => _orderLines;

        public void AddLineItem(OrderLine lineItem)
        {
            _orderLines.Add(lineItem);
        }

        public void RemoveLineItem(int bookId)
        {
            _orderLines.Remove(_orderLines.FirstOrDefault(li => li.Book.Id == bookId));
        }
    }
}
