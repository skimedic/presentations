using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace WPF.Models
{
	public partial class Product : ModelBase
	{
		public override string this[string columnName]
		{
			get
			{
				switch (columnName)
				{
					case nameof(Inventory):
						ClearErrors(columnName);
						CheckSalePrice(columnName);
						if (Inventory < 0)
						{
							AddError("Inventory can not be less than zero", columnName);
						}
						CheckSalePrice(nameof(SalePrice));

						break;
					case nameof(ModelName):
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
					case nameof(Price):
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
					case nameof(SalePrice):
						ClearErrors(columnName);
						CheckSalePrice(columnName);
						if (SalePrice < 0)
						{
							AddError("Sale Price can not be less than zero", columnName);
						}
						CheckSalePrice(nameof(Inventory));
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
			if (Inventory < 0)
			{
				//TODO: Fix this
			}
		}


	}
}
