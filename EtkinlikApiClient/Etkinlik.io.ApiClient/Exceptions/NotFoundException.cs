using EtkinlikIO.ApiClient.Models.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinlikIO.ApiClient.Exceptions
{
    public class NotFoundException : Exception
    {
        private GeneralErrorResponse response;

        public NotFoundException(GeneralErrorResponse response)
            : base(response.mesaj)
        {
            this.response = response;
        }

        public GeneralErrorResponse getResponse()
        {
            return this.response;
        }
    }
}
