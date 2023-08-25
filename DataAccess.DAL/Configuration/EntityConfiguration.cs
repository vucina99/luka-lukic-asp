﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL.Configuration
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.DeletedBy).HasMaxLength(40).IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasMaxLength(40).IsRequired(false);
            builder.Property(x => x.isActive).HasDefaultValue(true);

            BaseConfiguring(builder);
        }

        public abstract void BaseConfiguring(EntityTypeBuilder<T> builder);
    }
}
