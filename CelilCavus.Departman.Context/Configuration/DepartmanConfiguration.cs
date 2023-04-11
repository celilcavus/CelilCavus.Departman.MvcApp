using CelilCavus.Departman.Entity.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CelilCavus.Departman.Entity.Configuration
{
    public class DepartmanConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmanConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.DepartmanName).HasMaxLength(50);
            Property(x => x.DepartmanName).IsRequired();
        }
    }
}
