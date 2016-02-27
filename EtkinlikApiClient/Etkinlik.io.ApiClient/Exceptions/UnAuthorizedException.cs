using EtkinlikIO.ApiClient.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinlikIO.ApiClient.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public GeneralErrorResponse response;

        public UnauthorizedException(GeneralErrorResponse response)
            : base(response.mesaj)
        {
            this.response = response;
        }
    }
}
