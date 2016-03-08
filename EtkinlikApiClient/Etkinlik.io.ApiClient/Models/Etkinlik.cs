using EtkinlikIO.ApiClient.Models.Etkinlikler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinlikIO.ApiClient.Models
{
    public class Etkinlik
    {
        public int id { get; set; }

        public string adi { get; set; }

        public string radi { get; set; }

        public string url { get; set; }

        public string icerik { get; set; }

        public string baslangic { get; set; }

        public string bitis { get; set; }

        public bool ucretliMi { get; set; }

        public Ozellik ozellik { get; set; }

        public Tur tur { get; set; }

        public Kategori kategori { get; set; }

        public Mekan mekan { get; set; }

        public List<Etiket> etiketler { get; set; }
    }
}
