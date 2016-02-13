using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EtkinlikIO.ApiClient.Models.Reponses;

namespace EtkinlikIO.ApiClient.Exceptions
{
    public class BadRequestException : Exception
    {
        public GeneralErrorResponse response;

        public BadRequestException(GeneralErrorResponse response) : base(response.mesaj)
        {
            this.response = response;
        }
    }
}
