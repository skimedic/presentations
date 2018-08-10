#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - IRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace XUnitTestProject.C_Mocking
{
    public class FakeRepo : IRepo
    {
        public Customer Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetSome(Expression<Func<Customer, bool>> @where)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRepo
    {
        Customer Find(int id);
        IList<Customer> GetSome(Expression<Func<Customer, bool>> where);
    }
}