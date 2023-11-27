using Microsoft.EntityFrameworkCore;
using WebApiEF.Models;

namespace WebApiEF.Context
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
