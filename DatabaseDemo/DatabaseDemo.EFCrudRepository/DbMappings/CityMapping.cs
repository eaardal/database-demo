using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DatabaseDemo.DomainModel;

namespace DatabaseDemo.EFCrudRepository.DbMappings
{
    public class CityMapping : EntityTypeConfiguration<City>
    {
        public CityMapping()
        {
            Property(ctx => ctx.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(ctx => ctx.Name)
                .HasColumnName("Name")
                .IsRequired();

            HasMany(ctx => ctx.Citizens);

            ToTable("Cities");
        }
    }
}