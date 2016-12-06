using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF.Models
{
	public partial class Product
	{
		public int ID { get; set; }

		public string ModelName { get; set; }

		public string SKU { get; set; }

		public decimal Price { get; set; }

		public decimal SalePrice { get; set; }

		public int Inventory { get; set; }
	}
}
