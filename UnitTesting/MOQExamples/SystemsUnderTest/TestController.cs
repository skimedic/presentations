#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - TestController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion

using System;

namespace MOQExamples.SystemsUnderTest
{
    public class TestController
    {
        private readonly IRepo _repo;

        public TestController(IRepo repo)
        {
            _repo = repo;
        }

        public int TenantId() => _repo.TenantId;
        public void SetTenantId(int id) => _repo.TenantId = id;

        public Customer GetCustomer(int id)
        {
            try
            {
                return _repo.Find(id);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveCustomer(Customer customer)
        {
            _repo.AddRecord(customer);
        }
    }
}