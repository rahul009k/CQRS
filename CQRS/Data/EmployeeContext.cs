using CQRS.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CQRS.Data
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext>options):base(options)
        {
            
        }
       public DbSet<Employee> employees { get; set; }

    }
}
