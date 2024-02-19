using System;
using System.Collections.Generic;

namespace NorthwindRestApi.Models
{
    public partial class User
    {
        public User()
        {
            Loans = new HashSet<Loan>();
        }

        public int UserId { get; set; }
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
