﻿using System;
using System.Collections.Generic;

namespace Nova.Infrastructure.Data
{
    public partial class OrdersDetailsDynamic
    {
        public int IdOrderDatail { get; set; }
        public int? IdSize { get; set; }
        public int? Qty { get; set; }
        public int? IdOrder { get; set; }

        public virtual OrdersDynamic IdOrderNavigation { get; set; }
    }
}
