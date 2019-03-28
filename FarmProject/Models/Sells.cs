using System;
using System.Collections.Generic;

namespace FarmProject.Models
{
    public partial class Sells
    {
        public int SellId { get; set; }
        public int CategoryId { get; set; }
        public int VendorId { get; set; }

        public virtual Productcategory Category { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
