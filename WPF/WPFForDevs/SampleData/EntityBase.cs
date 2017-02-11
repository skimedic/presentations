#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - SampleData - EntityBase.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleData
{
	public abstract class EntityBase : INotifyPropertyChanged, INotifyDataErrorInfo
	{
		bool _isDirty;

		public bool IsDirty
		{
			get
			{
				return _isDirty;
			}
			set
			{
				if (_isDirty == value)
				{
					return;
				}
				_isDirty = value;
				OnNotifyPropertyChanged();
			}
		}

		public virtual event PropertyChangedEventHandler PropertyChanged;

		public virtual void OnNotifyPropertyChanged([CallerMemberName]
			string fieldName = "")
		{
			if (fieldName != "IsDirty")
				IsDirty = true;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(fieldName));
			//PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
		}


		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

		internal Dictionary<string, List<string>> Errors = new Dictionary<string, List<string>>();

		public bool HasErrors => (Errors.Count > 0);

		public IEnumerable GetErrors(string propertyName)
		{
			if (string.IsNullOrEmpty(propertyName))
			{
				return Errors.Values;
			}
			return Errors.ContainsKey(propertyName) ? (Errors[propertyName]) : null;
		}

		internal void RaiseErrorsChanged(string propertyName)
		{
			ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
		}

		internal void SetErrors(List<string> propertyErrors, [CallerMemberName]string propertyName = "")
		{
			Errors.Remove(propertyName);
			Errors.Add(propertyName, propertyErrors);
			RaiseErrorsChanged(propertyName);
		}
		internal void AddError(string error, [CallerMemberName]string propertyName = "")
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

		internal void ClearErrors([CallerMemberName]string propertyName = "")
		{
			Errors.Remove(propertyName);
			RaiseErrorsChanged(propertyName);
		}

	}
}