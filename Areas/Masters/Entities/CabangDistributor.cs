using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace simo2api.Areas.Masters.Entities
{

    public class CabangDistributor
    {
        public int CabangId { get; set; }
        public string? KodeCabang { get; set; }
        public string? NamaCabang { get; set; }

    }
}
