using Microsoft.EntityFrameworkCore;
using QueuingSystem.Models;
using System;

namespace QueuingSystem.DAL
{
    public class QueuingSystemContext : DbContext
    {
        public QueuingSystemContext(DbContextOptions<QueuingSystemContext> options)
            : base(options)
        {

        }

        public DbSet<Queues> Queues { get; set; }
    }
}
