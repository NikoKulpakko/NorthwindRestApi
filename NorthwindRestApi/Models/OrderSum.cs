using System;
using System.Collections.Generic;

namespace NorthwindRestApi.Models
{
    public partial class OrderSum
    {
        public int OrderId { get; set; }
        public double? Total { get; set; }
    }
}
