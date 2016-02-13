using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Etkinlik.io.ApiClient.Exceptions;
using Etkinlik.io.ApiClient.Models;
using Newtonsoft.Json;

namespace Etkinlik.io.ApiClient.Services
{
    public class SehirService
    {
        public ApiClient client { get; set; }
        public SehirService(ApiClient client)
        {
            this.client = client;
        }

        public List<Sehir> GetList()
        {
            Task<HttpResponseMessage> response = client.Call("/sehirler");

            switch (response.Result.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<List<Sehir>>(response.Result.Content.ReadAsStringAsync().Result);
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException();
            }
            throw new UnknownException(response.Result);
        }
    }

}
