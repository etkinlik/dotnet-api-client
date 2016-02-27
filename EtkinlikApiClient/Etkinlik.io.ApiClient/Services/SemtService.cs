using EtkinlikIO.ApiClient.Exceptions;
using EtkinlikIO.ApiClient.Models;
using EtkinlikIO.ApiClient.Models.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace EtkinlikIO.ApiClient.Services
{
    public class SemtService
    {
        private ApiClient client;

        public SemtService(ApiClient client)
        {
            this.client = client;
        }

        public List<Semt> GetListByIlceId(int ilceId)
        {
            HttpWebResponse response = client.ApiCall("/ilce/" + ilceId + "/semtler");

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string result = reader.ReadToEnd();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<List<Semt>>(result);

                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));
            }

            throw new UnknownException(response);
        }
    }
}
