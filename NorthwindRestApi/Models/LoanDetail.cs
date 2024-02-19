using System;
using System.Collections.Generic;

namespace NorthwindRestApi.Models
{
    public partial class LoanDetail
    {
        public int LoanDetailId { get; set; }
        public int? LoanId { get; set; }
        public int? ArticleId { get; set; }

        public virtual Article? Article { get; set; }
        public virtual Loan? Loan { get; set; }
    }
}
