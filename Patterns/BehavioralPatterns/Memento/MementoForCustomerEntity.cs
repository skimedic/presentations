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
