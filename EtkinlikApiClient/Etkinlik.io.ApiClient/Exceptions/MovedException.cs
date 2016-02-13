using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EtkinlikIO.ApiClient.Models.Reponses;

namespace EtkinlikIO.ApiClient.Exceptions
{
    public class MovedException : Exception
    {
        private EtkinlikMovedResponse response;

        public MovedException(EtkinlikMovedResponse response): base(response.mesaj)
        {
            this.response = response;
        }

		public EtkinlikMovedResponse getResponse()
		{
			return this.response;
		}
    }
}
