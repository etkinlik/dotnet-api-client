using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinlikIO.ApiClient.Models.Responses
{
    public class EtkinlikListeResponse
    {
        public Sayfalama sayfalama { get; set; }

        public List<Etkinlik> kayitlar { get; set; }
    }
}
