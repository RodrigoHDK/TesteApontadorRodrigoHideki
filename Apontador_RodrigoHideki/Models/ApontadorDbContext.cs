using System.Data.Entity;

namespace Apontador_RodrigoHideki.Models
{
    public class ApontadorDbContext : DbContext
    {
        public ApontadorDbContext() : base("Apontador")
        {
            Database.SetInitializer<ApontadorDbContext>
                (new DropCreateDatabaseIfModelChanges<ApontadorDbContext>());
        }

        public DbSet<Apontador> Apontador { get; set; }
    }
}