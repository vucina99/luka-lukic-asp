using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL.Configuration
{
    public class FilmImageConfiguration
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<FilmImage> builder)
        {
            builder.Property(x => x.Path).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ContentType).IsRequired().HasMaxLength(100);
        }
    }

}
