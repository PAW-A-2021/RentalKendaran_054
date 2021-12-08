using System;
using System.Collections.Generic;

#nullable disable

namespace RentalKendaran.Models
{
    public partial class JenisKendaraan
    {
        public int IdJenisKendaraan { get; set; }
        public string NamaJenisKendaraan { get; set; }

        public virtual Kendaraan IdJenisKendaraanNavigation { get; set; }
    }
}
