using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Persist Security Info=False;Integrated Security=true; Initial Catalog = School; Server = .");
        }
    }
}
