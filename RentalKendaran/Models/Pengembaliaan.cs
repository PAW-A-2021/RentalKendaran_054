using System;
using System.Collections.Generic;

#nullable disable

namespace RentalKendaran.Models
{
    public partial class Pengembaliaan
    {
        public int IdPengembalian { get; set; }
        public DateTime? TglPengembalian { get; set; }
        public int? IdPeminjaman { get; set; }
        public int? IdKondisi { get; set; }
        public int? Denda { get; set; }

        public virtual Kondisi Kondisi { get; set; }
        public virtual Pengembalian Pengembalian { get; set; }
    }
}
