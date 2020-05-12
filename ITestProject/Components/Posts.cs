using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITestProject
{
    public class Posts
    {
        public int userId { get; set; }
        public int id { get; set; }

        [DeserializeAs(Name = "title")]
        public string title { get; set; }
        public string body { get; set; }
    }
}
