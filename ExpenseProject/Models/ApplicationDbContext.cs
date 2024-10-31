using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ExpenseProject.Models
{
    public class ApplicationDbContext:DbContext

    {
        public  ApplicationDbContext (DbContextOptions options):base(options)

        {
             }
            public DbSet<Transaction> Transaction { get; set; }
        public DbSet<cate> cate { get; set; }

    }
}

