using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Etkinlik.io.ApiClient.Exceptions;
using Etkinlik.io.ApiClient.Models;
using Etkinlik.io.ApiClient.Models.Reponses;
using Etkinlik.io.ApiClient.Models.Requests;
using Newtonsoft.Json;

namespace Etkinlik.io.ApiClient.Services
{
    public class EtkinlikService
    {
        public ApiClient client { get; set; }

        public EtkinlikService(ApiClient client)
        {
            this.client = client;
        }

        public EtkinlikListeResponse GetList(EtkinlikListeConfig config = null)
        {
            string adres = "";
            if (config != null)
            {
                adres = "?" + config.Params().ToString();
            }
            Task<HttpResponseMessage> response = client.Call("/etkinlikler" + adres);
            switch (response.Result.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<EtkinlikListeResponse>(
                        response.Result.Content.ReadAsStringAsync().Result);
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException();
            }
            throw new UnknownException(response.Result);
        }

        public Models.Etkinlik GetById(int id)
        {
            Task<HttpResponseMessage> response = client.Call("/etkinlik/" + id);
            string result = response.Result.Content.ReadAsStringAsync().Result;
            switch (response.Result.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<Models.Etkinlik>(result);
                case HttpStatusCode.Moved:
                    throw new MovedException(JsonConvert.DeserializeObject<EtkinlikMovedResponse>(result));
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));
                case HttpStatusCode.NotFound:
                    throw new NotFoundException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));
            }
            throw new UnknownException(response.Result);
        }
    }
}
