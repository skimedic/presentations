#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - AddNewProductCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Windows;
using System.Windows.Input;
using SampleData;
using WPFDemo.BaseClasses;
using WPFDemo.E_DataBinding.Helpers;

namespace WPFDemo.E_DataBinding.Commands
{
	public class AddNewProductCommand : CommandBase
	{
		public override void Execute(object parameter)
		{
			var param = parameter as AddNewProductParameter;
			if (param?.Category == null)
			{
				return;
			}
			if (param.Product != null && param.Product.IsDirty)
			{
				return;
			}
			var newp = new Product() { UnitCost = 0, ModelName = "New Product" };
			newp.SetCategoryParent(param.Category);
			//cboProducts.SelectedItem = p;
		}

		public override bool CanExecute(object parameter)
		{
			var param = parameter as AddNewProductParameter;
			if (param?.Category == null)
			{
				return false;
			}
			return param.Product == null || !param.Product.IsDirty;
		}

	}
}