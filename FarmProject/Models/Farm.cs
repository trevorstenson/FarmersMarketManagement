using System;
using System.Collections.Generic;

namespace FarmProject.Models
{
    public partial class Farm
    {
        public Farm()
        {
            Vendor = new HashSet<Vendor>();
        }

        public int FarmId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string MainProduct { get; set; }

        public virtual ICollection<Vendor> Vendor { get; set; }
    }
}
