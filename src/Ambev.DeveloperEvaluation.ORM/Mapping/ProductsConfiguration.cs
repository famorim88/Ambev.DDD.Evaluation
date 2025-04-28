using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            // Propriedades
            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.Price)
                   .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Description)
                   .HasMaxLength(1000);

            builder.Property(p => p.Category)
                   .HasMaxLength(100);

            builder.Property(p => p.Image)
                   .HasMaxLength(500);

            // Tipo complexo: Rating (own type)
            builder.OwnsOne(p => p.Rating, rating =>
            {
                rating.Property(r => r.Rate).HasColumnName("Rating_Rate");
                rating.Property(r => r.Count).HasColumnName("Rating_Count");
            });

        }
    }
}
