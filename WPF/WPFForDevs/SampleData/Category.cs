#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - SampleData - Category.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData
{
	public class Category : EntityBase
	{
		string _categoryName;
		private ObservableCollection<Product> _products;
		public int ID { get; set; }
		public string CategoryName
		{
			get { return _categoryName; }
			set
			{
				if (_categoryName == value)
				{
					return;
				}
				_categoryName = value;
				if (_categoryName != null && _categoryName.Length > 50)
				{
					AddError("Invalid value for Category Name. Name must be less than 50 characters");
				}

				OnNotifyPropertyChanged();
			}
		}
		public virtual void AddProductChild(Product child)
		{
			if (child.CategoryParent == this)
			{
				return;
			}
			if (child.CategoryParent != null)
			{
				child.CategoryParent.ProductList.Remove(child);
			}
			if (!ProductList.Contains(child))
			{
				ProductList.Add(child);
			}
			child.CategoryParent = this;
		}
		public ObservableCollection<Product> ProductList
		{
			get { return _products ?? (_products = new ObservableCollection<Product>()); }
			set { _products = value; }
		}
	}
}
