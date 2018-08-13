using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MOQExamples.SystemsUnderTest
{
    public class FakeRepo : IRepo
    {
        public event EventHandler FailedDatabaseRequest;
        public int TenantId { get; set; }

        public Customer Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetSome(Expression<Func<Customer, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public void AddRecord(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}