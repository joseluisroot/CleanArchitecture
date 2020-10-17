using System;
using System.Collections.Generic;

namespace Nova.Infrastructure.Data
{
    public partial class OrderType
    {
        public OrderType()
        {
            Orders = new HashSet<Orders>();
        }

        public int IdOrderType { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
