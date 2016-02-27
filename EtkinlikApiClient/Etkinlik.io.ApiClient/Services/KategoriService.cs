using EtkinlikIO.ApiClient.Exceptions;
using EtkinlikIO.ApiClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EtkinlikIO.ApiClient.Services
{
    public class KategoriService
    {
        private ApiClient client;

        public KategoriService(ApiClient client)
        {
            this.client = client;
        }

        public List<Kategori> GetList()
        {
            HttpWebResponse response = client.ApiCall("/kategoriler");
            StreamReader reader = new StreamReader(response.GetResponseStream());
            
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<List<Kategori>>(reader.ReadToEnd());

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException();
            }
            throw new UnknownException(response);

        }
    }
}
