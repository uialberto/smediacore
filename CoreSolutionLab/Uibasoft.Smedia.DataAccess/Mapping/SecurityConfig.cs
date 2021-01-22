using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.Core.Enumerations;

namespace Uibasoft.Smedia.DataAccess.Mapping
{
    public class SecurityConfig : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.ToTable("Seguridad");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                    .HasColumnName("Id");

            builder.Property(e => e.Nombres)
                .HasColumnName("Nombres")
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Username)
                           .HasColumnName("Usuario")
                           .IsRequired()
                           .HasMaxLength(100)
                           .IsUnicode(false);

            builder.Property(e => e.Password)
               .HasColumnName("Contrasenia")
               .IsRequired()
               .HasMaxLength(200)
               .IsUnicode(false);


            builder.Property(e => e.Role)
               .HasColumnName("Rol")
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(false).HasConversion(
                    x => x.ToString(),
                    x => (RoleType)Enum.Parse(typeof(RoleType), x)
                );
        }
    }
}
