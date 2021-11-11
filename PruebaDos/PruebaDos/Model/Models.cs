using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PruebaDos.Model
{
    public class Models
    {
        public class MyDbContext : DbContext
        {

            public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
            {

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

            }

            public DbSet<TicketModel> TicketModel { get; set; }
        }
    }
}
