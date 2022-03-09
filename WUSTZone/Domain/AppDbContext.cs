using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WUSTZone.Domain.Entityies;

namespace WUSTZone.Domain
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 设置用户名唯一性约束
            modelBuilder.Entity<User>().HasIndex(user => user.UserName).IsUnique();
            // 设置时间戳
            modelBuilder.Entity<Post>().Property(post => post.TimeStamp).HasDefaultValueSql("CURRENT_TIMESTAMP");

            
        }

       
    }
}
