using _14362_ExpenseManager.DAL.Models;
using System.Collections.Generic;

namespace _14362_ExpenseManager.DAL.Data
{
    public class GeneralDBContext : DbContext
    {
        public GeneralDBContext(DbContextOptions<GeneralDBContext> options) : base(options) { }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<ExpenseType> ExpenseType { get; set; }
    }
}
