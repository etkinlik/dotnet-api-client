using EtkinlikIO.ApiClient.Exceptions;
using EtkinlikIO.ApiClient.Models;
using EtkinlikIO.ApiClient.Models.Requests;
using EtkinlikIO.ApiClient.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;


namespace EtkinlikIO.ApiClient.Services
{
    public class EtkinlikService
    {
        private ApiClient client;

        public EtkinlikService(ApiClient client)
        {
            this.client = client;
        }

        public EtkinlikListeResponse GetList(EtkinlikListeConfig config = null)
        {
            string queryString = config == null ? "" : "?" + config.Params().ToString();

            HttpWebResponse response = client.ApiCall("/etkinlikler" + queryString);

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string result = reader.ReadToEnd();

            switch (response.StatusCode)
            {

                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<EtkinlikListeResponse>(result);

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));
            }

            throw new UnknownException(response);
        }

        public Etkinlik GetById(int id)
        {
            HttpWebResponse response = client.ApiCall("/etkinlik/" + id);

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string result = reader.ReadToEnd();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<Etkinlik>(result);

                case HttpStatusCode.Moved:
                    throw new MovedException(JsonConvert.DeserializeObject<EtkinlikMovedResponse>(result));

                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));

                case HttpStatusCode.NotFound:
                    throw new NotFoundException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));
            }

            throw new UnknownException(response);
        }
    }
}
