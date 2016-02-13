using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etkinlik.io.ApiClient.Models.Reponses;

namespace Etkinlik.io.ApiClient.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public GeneralErrorResponse response;

        public UnauthorizedException(GeneralErrorResponse response) : base(response.mesaj)
        {
            this.response = response;
        }
    }
}
