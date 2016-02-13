using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EtkinlikIO.ApiClient.Exceptions
{
    public class UnknownException : Exception
    {
        public HttpResponseMessage response { get; set; }

        public UnknownException (HttpResponseMessage response)
        {
            this.response = response;
        }
    }
}
