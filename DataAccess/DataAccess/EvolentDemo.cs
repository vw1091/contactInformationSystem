
using System.Data.Entity;
namespace DataAccess
{

    public partial class EvolentDemo : DbContext
    {
        public EvolentDemo()
            : base("name=EvolentDemo")
        {
        }

        public virtual DbSet<ContactInformation> ContactInformations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactInformation>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<ContactInformation>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<ContactInformation>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ContactInformation>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);
        }
    }
}
