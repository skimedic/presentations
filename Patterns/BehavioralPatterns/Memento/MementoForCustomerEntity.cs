// Copyright Information
// =============================
// BehavioralPatterns - MementoForCustomerEntity.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================
using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Memento
{
    public class MementoForCustomerEntity
    {
        private Customer _customer;

        public MementoForCustomerEntity(Customer customer)
        {
            _customer = customer.Clone();
        }

        public Customer GetCustomer()
        {
            return _customer;
        }
        
    }
}
