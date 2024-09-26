using Microsoft.EntityFrameworkCore;
using BookXpertAssignment.Models;

namespace BookXpertAssignment.Dbcontexts
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

       
    }
}

