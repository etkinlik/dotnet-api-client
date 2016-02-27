using EtkinlikIO.ApiClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EtkinlikIO.ApiClient
{
    public class ApiClient
    {
        public string Token { get; private set; }

        public EtkinlikService EtkinlikService { get; private set; }

        public TurService TurService { get; private set; }

        public KategoriService KategoriService { get; private set; }

        public SehirService SehirService { get; private set; }

        public IlceService IlceService { get; private set; }

        public SemtService SemtService { get; private set; }

        public ApiClient(string Token)
        {
            this.Token = Token;

            this.EtkinlikService = new EtkinlikService(this);
            this.TurService = new TurService(this);
            this.KategoriService = new KategoriService(this);
            this.SehirService = new SehirService(this);
            this.IlceService = new IlceService(this);
            this.SemtService = new SemtService(this);
        }

        public HttpWebResponse ApiCall(string adres)
        {
            var url = new Uri("https://etkinlik.io/api/v1" + adres);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-ETKINLIK-TOKEN", this.Token);
            return (HttpWebResponse)request.GetResponse();
        }

    }
}
