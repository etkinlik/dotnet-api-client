using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etkinlik.io.ApiClient.Models;

namespace Etkinlik.io.ApiClient.Services
{
    public class TurService
    {
        public void List()
        {
            ApiService _api = new ApiService();
            _api.Call(this);
        }
        internal void Give(string responseData)
        {
            Console.WriteLine(responseData);
        }
    }
}
