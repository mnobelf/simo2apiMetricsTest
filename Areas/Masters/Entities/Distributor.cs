using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simo2api.Areas.Masters.Entities
{
    public class Distributor
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string? Nama { get; set; }
        public string ? NoKontrakDistributor { get; set; }
        public string ? Alamat { get; set; }
        public string ? NamaPerusahaanKecil { get; set; }
        public string ? Email { get; set; }
    }
}
