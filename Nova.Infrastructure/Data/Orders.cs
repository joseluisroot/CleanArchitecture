using System;
using System.Collections.Generic;

namespace Nova.Infrastructure.Data
{
    public partial class Orders
    {
        public Orders()
        {
            OrdersDetails = new HashSet<OrdersDetails>();
        }

        public int IdOrder { get; set; }
        public string WorkOrder { get; set; }
        public DateTime? EntryDate { get; set; }
        public string EntryUser { get; set; }
        public int? IdType { get; set; }

        public virtual OrderType IdTypeNavigation { get; set; }
        public virtual ICollection<OrdersDetails> OrdersDetails { get; set; }
    }
}
