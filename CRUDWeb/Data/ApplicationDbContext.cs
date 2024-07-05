using Microsoft.EntityFrameworkCore;
using CRUDWeb.Models;

namespace CRUDWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

         
        }

        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
    }
}
