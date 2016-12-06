#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - ProductList.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace WPF.Models
{
    public interface IProductList : IList<Product>, INotifyCollectionChanged { }
    public class ProductList : IProductList
    {
        private readonly IList<Product> _products;

        public ProductList(IList<Product> products)
        {
            _products = products;
        }

        public IEnumerator<Product> GetEnumerator() => _products.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(Product item)
        {
            _products.Add(item);
            NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        public void Clear()
        {
            _products.Clear();
            NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(Product item) => _products.Contains(item);

        public void CopyTo(Product[] array, int arrayIndex)
        {
            _products.CopyTo(array, arrayIndex);
        }

        public bool Remove(Product item)
        {
            var removed = _products.Remove(item);
            if (removed)
            {
                NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
            }
            return removed;
        }

        public int Count => _products.Count;

        public bool IsReadOnly => _products.IsReadOnly;

        public int IndexOf(Product item) => _products.IndexOf(item);

        public void Insert(int index, Product item)
        {
            _products.Insert(index, item);
            NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void RemoveAt(int index)
        {
            _products.RemoveAt(index);
            NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public Product this[int index]
        {
            get { return _products?[index]; }
            set
            {
                _products[index] = value;
                NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, _products[index]));
            }
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private void NotifyCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            CollectionChanged?.Invoke(this, args);
        }
    }
}
