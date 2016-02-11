using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etkinlik.io.ApiClient.Services;

namespace Etkinlik.io.ApiClient
{
    public class ApiClient
    {
        public TurService _turService;

        public ApiClient()
        {
            _turService = new TurService();
        }
    }
}
