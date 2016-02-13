using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etkinlik.io.ApiClient.Models
{
    public class Mekan
    {
        public int id { get; set; }
        public string adi { get; set; }
        public string radi { get; set; }
        public string adresi { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string telefon { get; set; }
        public string websitesi { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public Ilce ilce { get; set; }
        public Semt semt { get; set; }

    }
}
