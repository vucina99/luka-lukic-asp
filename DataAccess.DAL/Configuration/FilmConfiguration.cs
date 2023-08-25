using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL.Configuration
{
    public class FilmConfiguration : EntityConfiguration<Film>
    {
        public override void BaseConfiguring(EntityTypeBuilder<Film> builder)
        {
            builder.Property(x => x.Language).IsRequired().HasMaxLength(70);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(270);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Duration).IsRequired();

            builder.HasMany(x => x.CategoryFilms)
                .WithOne(x => x.Film)
                .HasForeignKey(x => x.FilmId)
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
