using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Etkinlik.io.ApiClient.Models
{
    public class Ilce
    {
        public int id { get; set; }
        public string adi { get; set;  }
        public Sehir sehir { get; set; }
    }
}
