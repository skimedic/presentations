using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace XUnitTestProject.C_Mocking
{
    public interface IRepo
    {
        Customer Find(int id);
        IList<Customer> GetSome(Expression<Func<Customer, bool>> where);
    }
}