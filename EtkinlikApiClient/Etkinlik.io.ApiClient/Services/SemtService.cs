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
    public class SemtService
    {
		private ApiClient client;

		public SemtService(ApiClient client)
		{
			this.client = client;
		}

        public List<Semt> GetListByIlceId(int ilceId)
        {
            Task<HttpResponseMessage> response = client.ApiCall("/ilce/" + ilceId + "/semtler");
            
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
