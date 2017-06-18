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