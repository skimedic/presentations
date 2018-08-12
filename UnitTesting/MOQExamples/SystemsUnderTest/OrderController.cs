namespace MOQExamples.SystemsUnderTest
{
    public class OrderController
    {
        private readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order = order;
        }
        public Customer GetCustomer()
        {
            return _order.CustomerOnOrder;
        }
    }
}