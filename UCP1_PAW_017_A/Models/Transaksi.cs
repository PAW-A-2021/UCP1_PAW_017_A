using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_017_A.Models
{
    public partial class Transaksi
    {
        public int IdTransaksi { get; set; }
        public int? IdProduk { get; set; }
        public int? IdAdmin { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdKurir { get; set; }
        public int? TotalTransaksi { get; set; }

        public virtual Admin IdAdminNavigation { get; set; }
        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Kurir IdKurirNavigation { get; set; }
        public virtual Produk IdProdukNavigation { get; set; }
    }
}
