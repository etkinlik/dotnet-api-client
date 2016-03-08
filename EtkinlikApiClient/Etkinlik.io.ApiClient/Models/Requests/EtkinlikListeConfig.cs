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
        //private List<int> turIds;

        private string turIds;
        private string kategoriIds;
        private string mekanIds;
        private string sehirIds;

        private int sayfa;
        private int adet;

        public NameValueCollection Params()
        {
            var query = HttpUtility.ParseQueryString(String.Empty);

            query.Add("turIds", this.turIds);
            query.Add("kategoriIds", this.kategoriIds);
            query.Add("mekanIds", this.mekanIds);
            query.Add("sehirIds", this.sehirIds);
            query.Add("sayfa", this.sayfa.ToString());
            query.Add("adet", this.adet.ToString());

            return query;
        }

        public EtkinlikListeConfig setTurIds(string turIds)
        {
            this.turIds = turIds;
            return this;
        }

        public EtkinlikListeConfig setKategoriIds(string kategoriIds)
        {
            this.kategoriIds = kategoriIds;
            return this;
        }

        public EtkinlikListeConfig setMekanIds(string mekanIds)
        {
            this.mekanIds = mekanIds;
            return this;
        }

        public EtkinlikListeConfig setSehirIds(string sehirIds)
        {
            this.sehirIds = sehirIds;
            return this;
        }

        public EtkinlikListeConfig setSayfa(int sayfa)
        {
            this.sayfa = sayfa;
            return this;
        }

        public EtkinlikListeConfig setAdet(int adet)
        {
            this.adet = adet;
            return this;
        }
    }
}
