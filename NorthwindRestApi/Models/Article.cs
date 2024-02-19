using System;
using System.Collections.Generic;

namespace NorthwindRestApi.Models
{
    public partial class Article
    {
        public Article()
        {
            LoanDetails = new HashSet<LoanDetail>();
        }

        public int ArticleId { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public byte[]? Image { get; set; }
        public DateTime Purchasedate { get; set; }
        public string Status { get; set; } = null!;
        public string? Warranty { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<LoanDetail> LoanDetails { get; set; }
    }
}
