using GeniusBase.Core.Database.Entity;
using GeniusBase.Core.Database.Entity.Post;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusBase.Core.Database
{
    public class GbContext : DbContext
    {
        public GbContext(DbContextOptions options) : base(options) { }

        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleHistory> ArticleHistory { get; set; }
        public DbSet<ArticleTag> ArticleTag { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Tag> Tag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(schema: DBGlobals.SchemaName_Post);

            modelBuilder.Entity<Article>().HasIndex(i => i.UrlIdentifier).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(i => i.CategoryIdentifier).IsUnique();
            modelBuilder.Entity<ArticleHistory>();
            modelBuilder.Entity<ArticleTag>();
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<Tag>();


            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
        
        public override int SaveChanges()
        {
            Audit();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            Audit();
            return await base.SaveChangesAsync();
        }

        private void Audit()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is EntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((EntityBase)entry.Entity).CreatedOn = DateTime.Now;
                }

                ((EntityBase)entry.Entity).ModifiedOn = DateTime.Now;
            }
        }
    }
}
