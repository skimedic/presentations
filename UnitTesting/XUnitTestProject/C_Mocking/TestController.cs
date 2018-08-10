#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - TestController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
namespace XUnitTestProject.C_Mocking
{
    public class TestController
    {
        private readonly IRepo _repo;

        public TestController(IRepo repo)
        {
            _repo = repo;
        }

        public Customer GetCustomer(int id)
        {
            return _repo.Find(id);
        }
    }
}