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
	public partial class Product_Combined 
	{

		private int _id;

		public int ID
		{
			get
			{
				return _id;
			}
			set
			{
				if (_id == value)
					return;
				_id = value;
				OnPropertyChanged();
			}
		}

		private string _modelName;

		public string ModelName
		{
			get
			{
				return _modelName;
			}
			set
			{
				if (_modelName == value)
					return;
				_modelName = value;
				OnPropertyChanged();
			}
		}

		private string _sku;

		public string SKU
		{
			get
			{
				return _sku;
			}
			set
			{
				if (_sku == value)
					return;
				_sku = value;
				OnPropertyChanged();
			}
		}

		private decimal _price;

		public decimal Price
		{
			get
			{
				return _price;
			}
			set
			{
				if (_price == value)
					return;
				_price = value;
				OnPropertyChanged();
			}
		}

		private decimal _salePrice;

		public decimal SalePrice
		{
			get
			{
				return _salePrice;
			}
			set
			{
				if (_salePrice == value)
					return;
				_salePrice = value;
				OnPropertyChanged();
			}
		}


		private int _inventory;

		public int Inventory
		{
			get
			{
				return _inventory;
			}
			set
			{
				if (_inventory == value)
					return;
				_inventory = value;
				OnPropertyChanged();
			}
		}




	}
}
