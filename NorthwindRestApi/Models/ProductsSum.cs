using System;
using System.Collections.Generic;

namespace NorthwindRestApi.Models
{
    public partial class ProductsSum
    {
        public int ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
