using EtkinlikIO.ApiClient.Exceptions;
using EtkinlikIO.ApiClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace EtkinlikIO.ApiClient.Services
{
    public class TurService
    {
        private ApiClient client;

        public TurService(ApiClient client)
        {
            this.client = client;
        }

        public List<Tur> GetList()
        {
            HttpWebResponse response = client.ApiCall("/turler");

            StreamReader reader = new StreamReader(response.GetResponseStream());

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<List<Tur>>(reader.ReadToEnd());

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException();
            }

            throw new UnknownException(response);
        }
    }
}
