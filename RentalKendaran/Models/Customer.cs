using System;
using System.Collections.Generic;

#nullable disable

namespace RentalKendaran.Models
{
    public partial class Customer
    {
        public int IdCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public string Nik { get; set; }
        public string Alamat { get; set; }
        public string NoHp { get; set; }
        public int? IdGender { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Pengembalian Pengembalian { get; set; }
    }
}
