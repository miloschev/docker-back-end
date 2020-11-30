using System;
using Microsoft.EntityFrameworkCore;
using VegaIT.Data.Entities;

namespace VegaIT.Data
{
    public class VegaMainDbContext : DbContext
    {
        public VegaMainDbContext(DbContextOptions<VegaMainDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}
