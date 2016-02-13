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
    public class SemtService
    {
        public ApiClient client { get; set; }
        public SemtService(ApiClient client)
        {
            this.client = client;
        }

        public List<Semt> GetListByIlceId(int ilceId)
        {
            Task<HttpResponseMessage> response = client.Call("/ilce/" + ilceId + "/semtler");
            string result = response.Result.Content.ReadAsStringAsync().Result;
            switch (response.Result.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<List<Semt>>(result);
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException(JsonConvert.DeserializeObject<GeneralErrorResponse>(result));
            }
            throw new UnknownException(response.Result);
        }
    }

}
