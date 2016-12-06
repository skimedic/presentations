#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - Product.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF.Models
{
	public class Product_40 : INotifyPropertyChanged, IDataErrorInfo
	{
		public enum FieldNames
		{
			ID,
			ModelName,
			SKU,
			Price,
			SalePrice,
			Inventory
		}

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

		private bool _isDirty;

		public bool IsDirty
		{
			get
			{
				return this._isDirty;
			}
			set
			{
				if (_isDirty == value)
					return;
				this._isDirty = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged([CallerMemberName]
			string fieldName = "")
		{
			if (fieldName != "IsDirty")
				IsDirty = true;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
			//PropertyChanged(this, new PropertyChangedEventArgs(fieldName));
		}

		public string this[string columnName]
		{
			get
			{
				var field = (FieldNames)Enum.Parse(typeof(FieldNames), columnName);
				switch (field)
				{
					case FieldNames.Inventory:
						if (Inventory < 0)
						{
							return "Inventory can not be less than zero";
						}
						break;
					case FieldNames.ModelName:
						if (ModelName.Contains("XXX"))
						{
							return "Our Store does not support adult content.";
						}
						break;
					case FieldNames.Price:
						if (Price < 0)
						{
							return "Price can not be less than zero";
						}
						break;
					case FieldNames.SalePrice:
						if (Inventory > 50 && SalePrice > (Price * .9M))
						{
							return ModelName + " must be marked down due to stock quantity greater than 50";
						}
						if (Inventory < 50 && SalePrice != Price)
						{
							return ModelName + " must not be marked down if the quantity is less than 50";
						}
						break;
					default:
						break;
				}
				return string.Empty;
			}
		}

		public string Error
		{
			get
			{
				throw new NotImplementedException(); 
			}
		}
	}
}