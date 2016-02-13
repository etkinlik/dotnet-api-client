using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EtkinlikIO.ApiClient.Exceptions;
using EtkinlikIO.ApiClient.Models;
using EtkinlikIO.ApiClient.Models.Reponses;
using EtkinlikIO.ApiClient.Models.Requests;
using Newtonsoft.Json;

namespace EtkinlikIO.ApiClient.Services
{
    public class EtkinlikService
    {
        private ApiClient client;

        public EtkinlikService (ApiClient client)
        {
            this.client = client;
        }

        public EtkinlikListeResponse GetList (EtkinlikListeConfig config = null)
        {
            string queryString = config == null ? "" : "?" + config.Params ().ToString ();
          
            Task<HttpResponseMessage> response = client.ApiCall ("/etkinlikler" + queryString);
            
            string result = response.Result.Content.ReadAsStringAsync ().Result;

            switch (response.Result.StatusCode) {

                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<EtkinlikListeResponse> (result);

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException (JsonConvert.DeserializeObject<GeneralErrorResponse> (result));
            }

            throw new UnknownException (response.Result);
        }

        public Etkinlik GetById (int id)
        {
            Task<HttpResponseMessage> response = client.ApiCall ("/etkinlik/" + id);

            string result = response.Result.Content.ReadAsStringAsync ().Result;

            switch (response.Result.StatusCode) {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<Etkinlik> (result);

                case HttpStatusCode.Moved:
                    throw new MovedException (JsonConvert.DeserializeObject<EtkinlikMovedResponse> (result));

                case HttpStatusCode.BadRequest:
                    throw new BadRequestException (JsonConvert.DeserializeObject<GeneralErrorResponse> (result));

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException (JsonConvert.DeserializeObject<GeneralErrorResponse> (result));

                case HttpStatusCode.NotFound:
                    throw new NotFoundException (JsonConvert.DeserializeObject<GeneralErrorResponse> (result));
            }

            throw new UnknownException (response.Result);
        }
    }
}
