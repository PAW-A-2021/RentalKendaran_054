using System;
using System.Collections.Generic;

#nullable disable

namespace RentalKendaran.Models
{
    public partial class Kondisi
    {
        public int IdKondisi { get; set; }
        public string NamaKondisi { get; set; }

        public virtual Pengembaliaan IdKondisiNavigation { get; set; }
    }
}
