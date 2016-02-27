using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EtkinlikIO.ApiClient.Models.Reponses;

namespace EtkinlikIO.ApiClient.Exceptions
{
    public class NotFoundException : Exception
    {
        private GeneralErrorResponse response;

        public NotFoundException (GeneralErrorResponse response) : base (response.mesaj)
        {
            this.response = response;
        }

        public GeneralErrorResponse getResponse ()
        {
            return this.response;
        }
    }
}
