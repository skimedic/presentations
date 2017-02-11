#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - SampleData - Product.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion

using System.ComponentModel;
using System.Globalization;

namespace SampleData
{
	public class Product40 : EntityBase, IDataErrorInfo
	{
		//Non Key Fields
		private string _modelNumber;
		private string _modelName;
		private decimal _unitCost;
		private decimal _currentPrice;
		private string _description;
		private int _unitsInStock;
		private Category _category;
		public override string ToString() => $"{ModelName} ({UnitCost.ToString(CultureInfo.InvariantCulture)}";

		private enum FieldNames
		{
			ModelNumber,
			ModelName,
			UnitCost,
			CurrentPrice,
			Description,
			UnitsInStock
		}
		public int ID { get; set; }
		public string ModelNumber
		{
			get { return _modelNumber; }
			set
			{
				if (_modelNumber == value)
				{
					return;
				}
				_modelNumber = value;
				OnNotifyPropertyChanged();
			}
		}
		public string ModelName
		{
			get { return _modelName; }
			set
			{
				if (_modelName == value)
				{
					return;
				}
				_modelName = value;
				OnNotifyPropertyChanged();
			}
		}
		public decimal UnitCost
		{
			get { return _unitCost; }
			set
			{
				if (_unitCost == value)
				{
					return;
				}
				_unitCost = value;
				OnNotifyPropertyChanged();
			}
		}
		public decimal CurrentPrice
		{
			get { return _currentPrice; }
			set
			{
				if (_currentPrice == value)
				{
					return;
				}
				_currentPrice = value;
				OnNotifyPropertyChanged();
			}
		}
		public string Description
		{
			get { return _description; }
			set
			{
				if (_description == value)
				{
					return;
				}
				_description = value;
				OnNotifyPropertyChanged();
			}
		}
		public int UnitsInStock
		{
			get { return _unitsInStock; }
			set
			{
				if (_unitsInStock == value)
				{
					return;
				}
				_unitsInStock = value;
				OnNotifyPropertyChanged();
			}
		}
		//public void SetCategoryParent(Category parent)
		//{
		//    if (CategoryParent != null)
		//    {
		//        CategoryParent.ProductList.Remove(this);
		//    }
		//    if (parent != null && !parent.ProductList.Contains(this))
		//    {
		//        parent.ProductList.Add(this);
		//    }
		//    CategoryParent = parent;
		//}

		public Category CategoryParent
		{
			get { return _category; }
			set
			{
				if (_category == value)
				{
					return;
				}
				_category = value;
				OnNotifyPropertyChanged();
			}
		}
		public virtual string this[string propertyName]
		{
			get
			{
				string errorInfo = string.Empty;
				CheckForErrors(ref errorInfo, propertyName);
				return errorInfo;
			}
		}
		void CheckForErrors(ref string errorInfo, string propertyName)
		{
			switch (propertyName)
			{
				case "ModelNumber":
					if (ModelNumber != null && ModelNumber.Contains("XXX"))
					{
						errorInfo = "ModelName can not contain adult content!";
					}
					break;
				case "ModelName":
					if (ModelName == null)
					{
						errorInfo = "Can't be null";
					}
					else if (ModelName != null && ModelName.Contains("XXX"))
					{
						errorInfo = "ModelName can not contain adult content!";
					}
					break;
				case "UnitCost":
					if (UnitCost < 0)
					{
						errorInfo = "Unit Cost can not be negative";
					}
					break;
				case "Description":
					if (Description != null && Description.Contains("XXX"))
					{
						errorInfo = "Description can not contain adult content!";
					}
					break;
				case "UnitsInStock":
					if (UnitsInStock < 0)
					{
						errorInfo = "Stock count can not be negative!";
					}
					break;
			}

		}
		public virtual string Error => string.Empty;
	}
}
