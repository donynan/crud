using crud.Model;
using Microsoft.EntityFrameworkCore;

namespace crud.Dbcontext
{
    public class EmployeeDbcontext : DbContext
    {
        public EmployeeDbcontext(DbContextOptions<EmployeeDbcontext> options) : base(options)
        {
        }
        public DbSet<employee> Employee { get; set; }
    }
}
