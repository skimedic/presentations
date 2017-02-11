#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - SampleData - Product.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion

using System.Globalization;

namespace SampleData
{
    public partial class Product : EntityBase
    {
        //Non Key Fields
        private string _modelNumber;
        private string _modelName;
        private decimal _unitCost;
        private decimal _currentPrice;
        private string _description;
        private int _unitsInStock;
        private Category _category;
        public override string ToString()
        {
            return $"{ModelName} ({UnitCost.ToString(CultureInfo.InvariantCulture)})";
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
                if (_modelNumber == null)
                {
                    AddError("Model Number can not be null");
                }
                else if (_modelNumber.Contains("XXX"))
                {
                    AddError("Model Number can not contain adult content!");
                }
                else
                {
                    ClearErrors();
                }
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
                if (_modelName == null)
                {
                    AddError("Model Name can not be null");
                }
                else if (_modelName.Contains("XXX"))
                {
                    AddError("Model Name can not contain adult content!");
                }
                else
                {
                    ClearErrors();
                }
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
                if (_unitCost < 0)
                {
                    AddError("Unit Cost can not be negative");
                }
                else
                {
                    ClearErrors();
                }
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
                if (_currentPrice < 0)
                {
                    AddError("Current Price can not be negative");
                }
                else
                {
                    ClearErrors();
                }
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
                if (_modelName.Contains("XXX"))
                {
                    AddError("Description can not contain adult content!");
                }
                else
                {
                    ClearErrors();
                } 
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
                if (_unitsInStock < 0)
                {
                    AddError("Units in stock can not be negative");
                }
                else
                {
                    ClearErrors();
                }
                OnNotifyPropertyChanged();
            }
        }
        public void SetCategoryParent(Category parent)
        {
            if (CategoryParent != null)
            {
                CategoryParent.ProductList.Remove(this);
            }
            if (parent != null && !parent.ProductList.Contains(this))
            {
                parent.ProductList.Add(this);
            }
            CategoryParent = parent;
        }

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
    }
}
