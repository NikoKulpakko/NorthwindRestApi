using System;
using System.Collections.Generic;

namespace NorthwindRestApi.Models
{
    public partial class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? Picture { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
