using System;
using System.Collections.Generic;

#nullable disable

namespace RentalKendaran.Models
{
    public partial class Pengembalian
    {
        public int IdPeminjaman { get; set; }
        public DateTime? TglPeminjaman { get; set; }
        public int? IdKendaraan { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdJaminan { get; set; }
        public int? Biaya { get; set; }

        public virtual Kendaraan IdKendaraanNavigation { get; set; }
        public virtual Pengembaliaan IdPeminjaman1 { get; set; }
        public virtual Customer IdPeminjamanNavigation { get; set; }
        public virtual Jaminan Jaminan { get; set; }
    }
}
