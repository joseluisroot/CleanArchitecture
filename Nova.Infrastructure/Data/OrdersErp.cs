using System;
using System.Collections.Generic;

namespace Nova.Infrastructure.Data
{
    public partial class OrdersErp
    {
        public OrdersErp()
        {
            OrdersDetailsErp = new HashSet<OrdersDetailsErp>();
        }

        public int IdOrder { get; set; }
        public string WorkOrder { get; set; }
        public DateTime? EntryDate { get; set; }
        public string EntryUser { get; set; }
        public int? IdOrdesOrigin { get; set; }

        public virtual ICollection<OrdersDetailsErp> OrdersDetailsErp { get; set; }
    }
}
