using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment4.Models;

namespace Assignment4.Data
{
    public class TrainDbContext : DbContext
    {
        internal object database;

        public TrainDbContext (DbContextOptions<TrainDbContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment4.Models.Train> Train { get; set; }
    }
}
