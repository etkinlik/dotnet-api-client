using EtkinlikIO.ApiClient.Exceptions;
using EtkinlikIO.ApiClient.Models;
using EtkinlikIO.ApiClient.Models.Reponses;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace EtkinlikIO.ApiClient.Services
{
    public class IlceService
    {
        private ApiClient client;

        public IlceService(ApiClient client)
        {
            this.client = client;
        }

        public List<Ilce> GetListBySehirId(int sehirId)
        {
            HttpWebResponse response = client.ApiCall("/sehir/" + sehirId + "/ilceler");

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string result = reader.ReadToEnd();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<List<Ilce>>(result);

                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));
            }

            throw new UnknownException(response);
        }
    }
}
