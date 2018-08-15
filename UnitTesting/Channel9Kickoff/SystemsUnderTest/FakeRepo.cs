using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Channel9Kickoff.SystemsUnderTest
{
    public class FakeDerivedRepo : FakeRepo
    {
    }
    public class FakeRepo : IRepo
    {
        //Must be virtual
        protected virtual int GetNumber() => 5;
        protected virtual int GetNumberWithParam(int param) => 5;

        public int CallProtectedMember()
        {
            return GetNumber();
        }
        public int CallProtectedMemberWithParam(int param)
        {
            return GetNumberWithParam(param);
        }


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