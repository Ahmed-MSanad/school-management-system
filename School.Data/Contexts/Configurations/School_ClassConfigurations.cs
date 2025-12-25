using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using School.Data.Entities;

namespace School.Data.Contexts.Configurations
{
    public class School_ClassConfigurations : IEntityTypeConfiguration<School_Class>
    {
        public void Configure(EntityTypeBuilder<School_Class> builder)
        {
            builder.HasIndex(sc => sc.Name).IsUnique();
        }
    }
}
