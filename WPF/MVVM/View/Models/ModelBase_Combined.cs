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
	public abstract class ModelBase_Combined : INotifyPropertyChanged, INotifyDataErrorInfo, IDataErrorInfo
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName]string fieldName = "")
		{
			if (fieldName != "IsDirty")
				IsDirty = true;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
			//PropertyChanged(this, new PropertyChangedEventArgs(fieldName));
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

		protected Dictionary<string, List<string>> Errors = new Dictionary<string, List<string>>();
		public bool HasErrors => (Errors.Count > 0);

		public IEnumerable GetErrors(string propertyName)
		{
			if (string.IsNullOrEmpty(propertyName))
			{
				return Errors.Values;
			}
			if (Errors.ContainsKey(propertyName))
			{
				return (Errors[propertyName]);
			}
			return null;
		}

		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

		private void RaiseErrorsChanged(string propertyName)
		{
			ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
		}

		protected void SetErrors(List<string> propertyErrors, [CallerMemberName]string propertyName = "")
		{
			Errors.Remove(propertyName);
			Errors.Add(propertyName, propertyErrors);
			RaiseErrorsChanged(propertyName);
		}

		protected void AddError(string error, [CallerMemberName]string propertyName = "")
		{
			if (!Errors.ContainsKey(propertyName))
			{
				Errors.Add(propertyName, new List<string>());
			}
			if (!Errors[propertyName].Contains(error))
			{
				Errors[propertyName].Add(error);
				RaiseErrorsChanged(propertyName);
			}
		}

		protected void ClearErrors([CallerMemberName]string propertyName = "")
		{
			Errors.Remove(propertyName);
			RaiseErrorsChanged(propertyName);

		}

		public abstract string this[string columnName]
		{
			get;
		}

		public string Error
		{
			get { throw new NotImplementedException(); }
		}
	}
}
