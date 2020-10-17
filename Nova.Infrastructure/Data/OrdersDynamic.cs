using System;
using System.Collections.Generic;

namespace Nova.Infrastructure.Data
{
    public partial class OrdersDynamic
    {
        public OrdersDynamic()
        {
            OrdersDetailsDynamic = new HashSet<OrdersDetailsDynamic>();
        }

        public int IdOrder { get; set; }
        public string WorkOrder { get; set; }
        public DateTime? EntryDate { get; set; }
        public string EntryUser { get; set; }
        public int? IdOrdesOrigin { get; set; }

        public virtual ICollection<OrdersDetailsDynamic> OrdersDetailsDynamic { get; set; }
    }
}
