using System;
using System.Collections.Generic;

namespace FarmProject.Models
{
    public partial class Participates
    {
        public int ParticipationId { get; set; }
        public int MarketId { get; set; }
        public int VendorId { get; set; }

        public virtual Market Market { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
