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

namespace MOQExamples.SystemsUnderTest
{
    public interface IOrder
    {
        Customer CustomerOnOrder { get;set; }
    }
    public interface IRepo
    {
        int TenantId { get; set; }
        Customer Find(int id);
        IList<Customer> GetSome(Expression<Func<Customer, bool>> where);
        void AddRecord(Customer customer);
    }
}