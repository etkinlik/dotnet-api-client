using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Etkinlikio.ApiClient.Test.Models
{
    public class EtkinlikFilter
    {
        public string turIds { get; set; }
        public string kategoriIds { get; set; }
        public string mekanIds { get; set; }
        public string sehirIds { get; set; }
        public int sayfa { get; set; }
        public int adet { get; set; }
    }
}