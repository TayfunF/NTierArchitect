using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchitect.Core.Models;

namespace NTierArchitect.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Kalem1", Stock = 20, Price = 40, CategoryId = 1 },
                new Product { Id = 2, Name = "Kalem2", Stock = 110, Price = 25, CategoryId = 1 },
                new Product { Id = 3, Name = "Kitap1", Stock = 75, Price = 150, CategoryId = 2 },
                new Product { Id = 4, Name = "Defter1", Stock = 60, Price = 30, CategoryId = 3 });
        }
    }
}
