using System;
using System.Collections.Generic;

namespace Nova.Infrastructure.Data
{
    public partial class OrdersPoly
    {
        public int IdOrder { get; set; }
        public string WorkOrder { get; set; }
        public DateTime? EntryDate { get; set; }
        public string EntryUser { get; set; }
        public int? IdOrdesOrigin { get; set; }

        public virtual OrdersDetailsPoly OrdersDetailsPoly { get; set; }
    }
}
