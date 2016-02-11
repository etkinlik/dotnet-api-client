using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etkinlik.io.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiClient.ApiClient _api = new ApiClient.ApiClient();
            _api._turService.List();
            Console.ReadKey();
        }
    }
}
