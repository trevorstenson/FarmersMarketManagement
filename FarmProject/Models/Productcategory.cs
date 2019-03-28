using System;
using System.Collections.Generic;

namespace FarmProject.Models
{
    public partial class Productcategory
    {
        public Productcategory()
        {
            Sells = new HashSet<Sells>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Sells> Sells { get; set; }
    }
}
