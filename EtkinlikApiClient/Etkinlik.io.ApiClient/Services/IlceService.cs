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
using Etkinlik.io.ApiClient.Models.Reponses;
using Newtonsoft.Json;

namespace Etkinlik.io.ApiClient.Services
{
    public class IlceService
    {
        public ApiClient client { get; set; }
        public IlceService(ApiClient client)
        {
            this.client = client;
        }

        public List<Ilce> GetListBySehirId(int sehirId)
        {
            Task<HttpResponseMessage> response = client.Call("/sehir/" + sehirId + "/ilceler");
            string result = response.Result.Content.ReadAsStringAsync().Result;
            switch (response.Result.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<List<Ilce>>(result);
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));
            }
            throw new UnknownException(response.Result);
        }
    }

}
