using System;
using HugDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace HugDb
{
    public class HugDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } // Lenteles atitikmuo duombazeje
        public DbSet<Hug> Hugs { get; set; }
        public HugDbContext(DbContextOptions<HugDbContext> options) : base(options)
        {

        }
    }
}
