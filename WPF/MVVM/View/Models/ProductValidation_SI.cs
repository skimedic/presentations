using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models
{
	public partial class Product_Combined : ModelBase_Combined
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

		public override string this[string columnName]
		{
			get
			{
				var field = (FieldNames)Enum.Parse(typeof(FieldNames), columnName);
				switch (field)
				{
					case FieldNames.Inventory:
						ClearErrors(columnName);
						CheckSalePrice(columnName);
						if (SalePrice < 0)
						{
							AddError("Inventory can not be less than zero", columnName);
						}
						CheckSalePrice(FieldNames.SalePrice.ToString());

						break;
					case FieldNames.ModelName:
						if (ModelName.Contains("XXX"))
						{
							var errors = new List<string>() { "Our Store does not support adult content." };
							SetErrors(errors, columnName);
						}
						else
						{
							ClearErrors(columnName);
						}
						break;
					case FieldNames.Price:
						if (Price < 0)
						{
							var errors = new List<string>() { "Price can not be less than zero" };
							SetErrors(errors, columnName);
						}
						else
						{
							ClearErrors(columnName);
						}
						break;
					case FieldNames.SalePrice:
						ClearErrors(columnName);
						CheckSalePrice(columnName);
						if (SalePrice < 0)
						{
							AddError("Sale Price can not be less than zero", columnName);
						}
						CheckSalePrice(FieldNames.Inventory.ToString());
						break;
					default:
						break;
				}
				return string.Empty;
			}
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
