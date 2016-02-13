using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using Etkinlik.io.ApiClient.Models.Reponses;

namespace Etkinlik.io.ApiClient.Exceptions
{
    public class MovedException : Exception
    {
        private EtkinlikMovedResponse _response;

        public MovedException(EtkinlikMovedResponse response): base(response.mesaj)
        {
            this._response = response;
        }
    }
}
