using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace EtkinlikIO.ApiClient.Exceptions
{
    public class UnknownException : Exception
    {
        public HttpWebResponse response { get; set; }

        public UnknownException(HttpWebResponse response)
        {
            this.response = response;
        }
    }
}
