using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etkinlik.io.ApiClient.Models.Reponses;

namespace Etkinlik.io.ApiClient.Exceptions
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
