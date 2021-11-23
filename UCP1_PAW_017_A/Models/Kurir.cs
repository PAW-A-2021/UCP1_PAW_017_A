using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_017_A.Models
{
    public partial class Kurir
    {
        public Kurir()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdKurir { get; set; }
        public string NamaKurir { get; set; }
        public string NoHp { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
