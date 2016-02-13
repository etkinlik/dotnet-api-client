using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Etkinlik.io.ApiClient.Services;

namespace Etkinlik.io.ApiClient
{
    public class ApiClient
    {
        public string Token { get; set; }
        public SehirService sehirService { get; set; }
        public KategoriService kategoriService { get; set; }
        public TurService turService { get; set; }
        public EtkinlikService etkinlikService { get; set; }

        public ApiClient(string token)
        {
            Token = token;
            this.turService = new TurService(this);
            this.etkinlikService = new EtkinlikService(this);
        }
        public async Task<HttpResponseMessage> Call(string adres)
        {
            var baseAddress = new Uri("https://etkinlik.io/");
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.Add("X-ETKINLIK-TOKEN", this.Token);
                return await httpClient.GetAsync("api/v1" + adres);
            }
        }
    }
}
