using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_017_A.Models
{
    public partial class Produk
    {
        public Produk()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdProduk { get; set; }
        public string NamaProduk { get; set; }
        public int? HargaProduk { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
