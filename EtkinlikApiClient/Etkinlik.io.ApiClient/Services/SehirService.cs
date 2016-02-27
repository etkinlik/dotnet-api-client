using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EtkinlikIO.ApiClient.Exceptions;
using EtkinlikIO.ApiClient.Models;
using Newtonsoft.Json;

namespace EtkinlikIO.ApiClient.Services
{
    public class SehirService
    {
        private ApiClient client;

        public SehirService (ApiClient client)
        {
            this.client = client;
        }

        public List<Sehir> GetList ()
        {
            Task<HttpResponseMessage> response = client.ApiCall ("/sehirler");

            switch (response.Result.StatusCode) {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<List<Sehir>> (response.Result.Content.ReadAsStringAsync ().Result);

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException ();
            }

            throw new UnknownException (response.Result);
        }
    }

}
