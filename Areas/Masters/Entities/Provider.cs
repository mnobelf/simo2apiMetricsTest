using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simo2api.Areas.Masters.Entities
{
    public class Provider
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
    public class GetProvider
    {
        public string ? ProviderID { get; set; }
    }
    public class DataProvider
    {
        public string? ProviderID { get; set; }
        public string? KDKC { get; set; }
        public string? KDPPK { get; set; }
        public string? Nama { get; set; }
        public string? Alamat { get; set; }

    }
}
