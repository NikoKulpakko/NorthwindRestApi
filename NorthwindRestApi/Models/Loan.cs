using System;
using System.Collections.Generic;

namespace NorthwindRestApi.Models
{
    public partial class Loan
    {
        public Loan()
        {
            LoanDetails = new HashSet<LoanDetail>();
        }

        public int LoanId { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public DateTime Loandate { get; set; }
        public DateTime Returndate { get; set; }
        public DateTime Duedate { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<LoanDetail> LoanDetails { get; set; }
    }
}
