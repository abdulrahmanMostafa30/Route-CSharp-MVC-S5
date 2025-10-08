using IKEA.DAL.Models;

namespace IKEA.DAL.Contexts
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbcontext).Assembly);
        }

        #region DbSet
        public DbSet<Department> Departments { get; set; }
        public DbSet<Models.Employee.Employee> Employees { get; set; }
        #endregion
    }
}
