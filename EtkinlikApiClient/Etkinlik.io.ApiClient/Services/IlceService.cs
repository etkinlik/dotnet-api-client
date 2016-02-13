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
using EtkinlikIO.ApiClient.Models.Reponses;
using Newtonsoft.Json;

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
            Task<HttpResponseMessage> response = client.ApiCall("/sehir/" + sehirId + "/ilceler");

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
