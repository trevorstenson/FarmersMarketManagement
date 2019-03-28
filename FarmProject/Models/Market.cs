using System;
using System.Collections.Generic;

namespace FarmProject.Models
{
    public partial class Market
    {
        public Market()
        {
            Participates = new HashSet<Participates>();
        }

        public int MarketId { get; set; }
        public string Name { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public string State { get; set; }
        public string Credit { get; set; }

        public virtual ICollection<Participates> Participates { get; set; }
    }
}
