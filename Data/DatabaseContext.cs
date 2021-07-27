using System;
using Microsoft.EntityFrameworkCore;
using ShortUrl.Models;

namespace ShortUrl.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ShortendUrl> ShortendUrls { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortendUrl>().ToTable("Urls");
        }
    }
}