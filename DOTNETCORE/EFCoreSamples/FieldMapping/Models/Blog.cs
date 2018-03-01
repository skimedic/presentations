using System;
using System.Net.Http;

namespace FieldMapping.Models
{
    public class Blog
    {
        //this will be used by EF when constituting an instance
        private string _url;
        private string _name;
        public int BlogId { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                {
                    return;
                }
                _name = value;
                PropertyChanged();
            }
        }

        public void PropertyChanged()
        {
            Console.WriteLine("Property Changed");
        }
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