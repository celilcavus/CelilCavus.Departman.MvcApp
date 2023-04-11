using CelilCavus.Departman.Entity.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CelilCavus.Departman.Entity.Configuration
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.JobTitle).HasMaxLength(50);
            Property(x => x.JobTitle).IsRequired();

            Property(x => x.Name).HasMaxLength(50);
            Property(x => x.Name).IsRequired();

            Property(x => x.LastName).HasMaxLength(50);
            Property(x => x.LastName).IsRequired();

            Property(x => x.PhoneNo).HasMaxLength(15);
            Property(x => x.PhoneNo).IsRequired();

            Property(x => x.Salary).HasMaxLength(50);
            Property(x => x.Salary).IsRequired();

        }
    }
}
