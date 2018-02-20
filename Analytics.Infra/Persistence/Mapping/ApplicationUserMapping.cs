using Analytics.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Infra.Persistence.Mapping
{
    public class ApplicationUserMapping : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserMapping()
        {
            ToTable("ApplicationUser");

            Property(p => p.Email)
                     .HasMaxLength(200)
                     .IsRequired()
                     .HasColumnAnnotation("Index",new IndexAnnotation(new IndexAttribute("UK_USER_EMAIL") { IsUnique = true }))
                     .HasColumnName("Email");

            Property(x => x.Name).IsRequired().HasMaxLength(50);
            Property(x => x.RegistrationId).IsRequired().HasMaxLength(50);
         

        }
    }
}
