namespace SpyStore.Mvc.Support
{
    public class ServiceSettings
    {
        public ServiceSettings() { }
        public string Uri { get; set; }
        public string CartBaseUri { get; set; }
        public string CartRecordBaseUri { get; set; }
        public string CategoryBaseUri { get; set; }
        public string CustomerBaseUri { get; set; }
        public string ProductBaseUri { get; set; }
        public string SearchBaseUri { get; set; }
        public string OrdersBaseUri { get; set; }
        public string OrderDetailsBaseUri { get; set; }

    }
}
