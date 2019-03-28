using System;
using System.Collections.Generic;

namespace FarmProject.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Participates = new HashSet<Participates>();
            Sells = new HashSet<Sells>();
        }

        public int VendorId { get; set; }
        public string Name { get; set; }
        public int? Stallcount { get; set; }
        public int? FarmId { get; set; }

        public virtual Farm Farm { get; set; }
        public virtual ICollection<Participates> Participates { get; set; }
        public virtual ICollection<Sells> Sells { get; set; }
    }
}
