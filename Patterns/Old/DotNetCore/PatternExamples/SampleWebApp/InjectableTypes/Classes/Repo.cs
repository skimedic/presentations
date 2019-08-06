using SampleWebApp.InjectableTypes.Interfaces;
using System;
using System.Collections.Generic;

namespace SampleWebApp.InjectableTypes.Classes
{
    public class CustomerRepo : IRepo<Customer>
    {
        public int Count { get; }
        public Customer Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Add(Customer entity, bool persist = true)
        {
            throw new NotImplementedException();
        }

        public int AddRange(IEnumerable<Customer> entities, bool persist = true)
        {
            throw new NotImplementedException();
        }

        public int Update(Customer entity, bool persist = true)
        {
            throw new NotImplementedException();
        }

        public int UpdateRange(IEnumerable<Customer> entities, bool persist = true)
        {
            throw new NotImplementedException();
        }

        public int Delete(Customer entity, bool persist = true)
        {
            throw new NotImplementedException();
        }

        public int DeleteRange(IEnumerable<Customer> entities, bool persist = true)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id, byte[] timeStamp, bool persist = true)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}