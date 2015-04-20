using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DatabaseDemo.DomainModel;

namespace DatabaseDemo.EFCrudRepository.DbMappings
{
    public class PersonMapping : EntityTypeConfiguration<Person>
    {
        public PersonMapping()
        {
            Property(ctx => ctx.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(ctx => ctx.FirstName)
                .HasColumnName("FirstName")
                .IsRequired();

            Property(ctx => ctx.LastName)
                .HasColumnName("LastName")
                .IsRequired();

            Property(ctx => ctx.Age)
                .HasColumnName("Age")
                .IsRequired();

            ToTable("People");
        }
    }
}
