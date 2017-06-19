// Copyright Information
// =============================
// XUnitTestProject - TestController.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
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