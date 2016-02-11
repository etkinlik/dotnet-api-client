using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Etkinlik.io.ApiClient.Services
{
    public class ApiService
    {
        public async void Call(TurService turService)
        {
            var baseAddress = new Uri("https://etkinlik.io/");
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.Add("X-ETKINLIK-TOKEN", "f84b2a1f11d17cdce09241e850a62be4");
                using (var response = await httpClient.GetAsync("api/v1/turler"))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    turService.Give(responseData);
                }
            }            
        }
    }
}
