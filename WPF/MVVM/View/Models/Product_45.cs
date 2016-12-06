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
	public class Product_45 : INotifyPropertyChanged, INotifyDataErrorInfo
	{
		public event PropertyChangedEventHandler PropertyChanged;

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
				if (Price < 0)
				{
					var propertyErrors = new List<string>() { "Price can not be less than zero" };
					SetErrors(propertyErrors);
				}
				else
				{
					ClearErrors();
				}
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
				ClearErrors();
				CheckSalePrice();
				if (SalePrice < 0)
				{
					AddError("Sale Price can not be less than zero");
				}
				CheckSalePrice("Inventory");
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
				ClearErrors();
				CheckSalePrice();
				if (Inventory < 0)
				{
					AddError("Sale Price can not be less than zero");
				}
				CheckSalePrice("SalePrice");
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

		private void OnPropertyChanged([CallerMemberName]
			string fieldName = "")
		{
			if (fieldName != "IsDirty")
				IsDirty = true;
			//PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(fieldName));
		}
				private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
		public bool HasErrors => (errors.Count > 0);

		public IEnumerable GetErrors(string propertyName)
		{
			if (string.IsNullOrEmpty(propertyName))
			{
				return errors.Values;
			}
			else
			{
				if (errors.ContainsKey(propertyName))
				{
					return (errors[propertyName]);
				}
				else
				{
					return null;
				}
			}
		}

		private void RaiseErrorsChanged(string propertyName)
		{
			ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
		}

		private void SetErrors(List<string> propertyErrors, [CallerMemberName]string propertyName = "")
		{
			errors.Remove(propertyName);
			errors.Add(propertyName, propertyErrors);
			RaiseErrorsChanged(propertyName);
		}
		private void AddError(string error, [CallerMemberName]string propertyName = "")
		{
			if (!errors.ContainsKey(propertyName))
			{
				errors.Add(propertyName, new List<string>());
			}
			if (!errors[propertyName].Contains(error))
			{
				errors[propertyName].Add(error);
				RaiseErrorsChanged(propertyName);
			}
		}

		private void ClearErrors([CallerMemberName]string propertyName = "")
		{
			errors.Remove(propertyName);
			RaiseErrorsChanged(propertyName);

		}

		private void CheckSalePrice([CallerMemberName]string propertyName = "")
		{
			if (Inventory > 50 && SalePrice > (Price * .9M))
			{
				string message = ModelName + " must be marked down due to stock quantity greater than 50";
				AddError(message, propertyName);
			}
			if (Inventory < 50 && SalePrice != Price)
			{
				string message = ModelName + " must not be marked down if the quantity is less than 50";
				AddError(message, propertyName);
			}
		}



	}
}
