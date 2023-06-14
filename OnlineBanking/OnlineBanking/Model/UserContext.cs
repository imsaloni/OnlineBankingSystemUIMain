using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Model
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions Options):base(Options)
        {

        }
        public DbSet<User> Users { get;  set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<AccountDetails> AccountDetailss { get; set; }
       public DbSet<Transaction> Transactionss { get; set; }
        public IEnumerable<object> AccountDetails { get; internal set; }
        public object Transaction { get; internal set; }
    }
}
