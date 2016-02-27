using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Etkinlikio.ApiClient.Test.Models
{
    public class EtkinlikFilter
    {
        public int turId { get; set; }
        public int kategoriId { get; set; }
        public int mekanId { get; set; }
        public int sehirId { get; set; }
        public int sayfa { get; set; }
        public int adet { get; set; }
    }
}