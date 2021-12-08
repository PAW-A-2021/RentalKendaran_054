using System;
using System.Collections.Generic;

#nullable disable

namespace RentalKendaran.Models
{
    public partial class Jaminan
    {
        public int IdJaminan { get; set; }
        public string NamaJaminan { get; set; }

        public virtual Pengembalian IdJaminanNavigation { get; set; }
    }
}
