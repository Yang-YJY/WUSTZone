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

        public AppDbContext(DbContextOptions options): base(options)
        {

        }
    }
}
