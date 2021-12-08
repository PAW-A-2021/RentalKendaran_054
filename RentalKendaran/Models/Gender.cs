using System;
using System.Collections.Generic;

#nullable disable

namespace RentalKendaran.Models
{
    public partial class Gender
    {
        public int IdGender { get; set; }
        public string NamaGender { get; set; }

        public virtual Customer IdGenderNavigation { get; set; }
    }
}
