using GeniusBase.Core.Database.Entity.Post;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusBase.Core.Database
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    CategoryName = "Uncategorized",
                    CategoryIdentifier = "uncategorized",
                    CreatedBy = 1,
                    ModifiedBy = 1
                }
            );

        }
    }
}
