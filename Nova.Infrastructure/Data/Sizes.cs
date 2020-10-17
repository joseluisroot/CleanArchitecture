using System;
using System.Collections.Generic;

namespace Nova.Infrastructure.Data
{
    public partial class Sizes
    {
        public Sizes()
        {
            OrdersDetails = new HashSet<OrdersDetails>();
        }

        public int IdSize { get; set; }
        public string Number { get; set; }

        public virtual ICollection<OrdersDetails> OrdersDetails { get; set; }
    }
}
