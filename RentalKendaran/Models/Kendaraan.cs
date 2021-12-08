using System;
using System.Collections.Generic;

#nullable disable

namespace RentalKendaran.Models
{
    public partial class Kendaraan
    {
        public Kendaraan()
        {
            Pengembalians = new HashSet<Pengembalian>();
        }

        public int IdKendaraan { get; set; }
        public string NamaKendaraan { get; set; }
        public string NoPolisi { get; set; }
        public string NoStnk { get; set; }
        public int? IdJenisKendaraan { get; set; }
        public string Ketersediaan { get; set; }

        public virtual JenisKendaraan JenisKendaraan { get; set; }
        public virtual ICollection<Pengembalian> Pengembalians { get; set; }
    }
}
