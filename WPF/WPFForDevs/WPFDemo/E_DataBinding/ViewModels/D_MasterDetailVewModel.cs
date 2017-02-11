#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - D_MasterDetailVewModel.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion

using System.Collections.Generic;
using System.Windows.Input;
using SampleData;
using WPFDemo.E_DataBinding.Commands;

namespace WPFDemo.E_DataBinding.ViewModels
{
	public class D_MasterDetailVewModel
	{
		private ICommand _closeCommand;

		private ICommand _saveCommand;

		private ICommand _updatePriceCommand;

		private ICommand _addNewProductCommand;

		private ICommand _deleteCommand;

		private ICommand _linkedDetailCommand;

		public ICommand LinkedDetail => _linkedDetailCommand ?? (_linkedDetailCommand = new LinkedFormCommand());

		public ICommand Delete => _deleteCommand ?? (_deleteCommand = new DeleteCommand());
		public ICommand AddNewProduct => _addNewProductCommand ?? (_addNewProductCommand = new AddNewProductCommand());
		public ICommand Close => _closeCommand ?? (_closeCommand = new CloseCommand());

		public ICommand Save => _saveCommand ?? (_saveCommand = new SaveCommand());

		public IList<Category> Categories => FakeRepo.GetAllCategories();

		public ICommand UpdatePrice => _updatePriceCommand ?? (_updatePriceCommand = new UpdatePriceCommand());
	}
}
