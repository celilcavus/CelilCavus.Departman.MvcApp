using CelilCavus.Departman.Entity.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CelilCavus.Departman.Entity.Configuration
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(x => x.ProjectName).HasMaxLength(50);
            Property(x => x.ProjectName).IsRequired();

            Property(x => x.ProjectStartDate).IsRequired();
            Property(x => x.ProjectEndDate).IsRequired();
        }
    }
}
