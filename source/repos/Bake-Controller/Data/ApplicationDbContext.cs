using Microsoft.EntityFrameworkCore;

namespace Bake_Controller.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<FurnaceController> FurnaceRecords { get; set; }
        public object Users { get; internal set; }
    }
}
