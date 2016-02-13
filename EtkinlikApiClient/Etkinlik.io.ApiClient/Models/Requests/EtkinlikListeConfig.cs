using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EtkinlikIO.ApiClient.Models.Requests
{
    public class EtkinlikListeConfig
    {
        private int turId;
        private int kategoriId;
        private int mekanId;
        private int sehirId;
        private int sayfa;
        private int adet;

        public NameValueCollection Params ()
        {
            var query = HttpUtility.ParseQueryString (String.Empty);
            query.Add ("turId", this.turId.ToString ());
            query.Add ("kategoriId", this.kategoriId.ToString ());
            query.Add ("mekanId", this.mekanId.ToString ());
            query.Add ("sehirId", this.sehirId.ToString ());
            query.Add ("sayfa", this.sayfa.ToString ());
            query.Add ("adet", this.adet.ToString ());
            return query;
        }

        public EtkinlikListeConfig setTurId (int turId)
        {
            this.turId = turId;
            return this;
        }

        public EtkinlikListeConfig setKategoriId (int kategoriId)
        {
            this.kategoriId = kategoriId;
            return this;
        }

        public EtkinlikListeConfig setMekanId (int mekanId)
        {
            this.mekanId = mekanId;
            return this;
        }

        public EtkinlikListeConfig setSehirId (int sehirId)
        {
            this.sehirId = sehirId;
            return this;
        }

        public EtkinlikListeConfig setSayfa (int sayfa)
        {
            this.sayfa = sayfa;
            return this;
        }

        public EtkinlikListeConfig setAdet (int adet)
        {
            this.adet = adet;
            return this;
        }
    }
}
