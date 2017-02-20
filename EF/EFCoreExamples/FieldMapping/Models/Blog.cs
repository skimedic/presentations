using System.Net.Http;

namespace FieldMapping.Models
{
    public class Blog
    {
        //this will be used by EF when constituting an instance
        private string _url;

        public int BlogId { get; set; }
        public string Name { get; set; }

        public string GetUrl()
        {
            return _url;
        }

        public void SetUrl(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
            }

            _url = url;
        }
    }
}