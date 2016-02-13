using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EtkinlikIO.ApiClient.Services;

namespace EtkinlikIO.ApiClient
{
    public class ApiClient
    {
        public string Token { get; }

        public EtkinlikService EtkinlikService { get; }

        public TurService TurService { get; }

        public KategoriService KategoriService { get; }

        public SehirService SehirService { get; }

        public IlceService IlceService { get; }

        public SemtService SemtService { get; }

        public ApiClient (string Token)
        {
            this.Token = Token;

            this.EtkinlikService = new EtkinlikService (this);
            this.TurService = new TurService (this);
            this.KategoriService = new KategoriService (this);
            this.SehirService = new SehirService (this);
            this.IlceService = new IlceService (this);
            this.SemtService = new SemtService (this);
        }

        public async Task<HttpResponseMessage> ApiCall (string adres)
        {
            var baseAddress = new Uri ("https://etkinlik.io/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress }) {
                
                httpClient.DefaultRequestHeaders.Add ("X-ETKINLIK-TOKEN", this.Token);

                return await httpClient.GetAsync ("api/v1" + adres);
            }
        }
    }
}
