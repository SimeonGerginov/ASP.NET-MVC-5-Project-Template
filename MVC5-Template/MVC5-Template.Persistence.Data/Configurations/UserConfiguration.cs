using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

using MVC5_Template.Core.Models;

namespace MVC5_Template.Persistence.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.Property(e => e.CreatedOn).HasColumnType("datetime2");
            this.Property(e => e.ModifiedOn).HasColumnType("datetime2");
            this.Property(e => e.DeletedOn).HasColumnType("datetime2");

            var indexAttribute = new IndexAttribute();
            var indexAnnotation = new IndexAnnotation(indexAttribute);

            this.Property(e => e.IsDeleted)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, indexAnnotation);
        }
    }
}
