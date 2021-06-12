using Microsoft.EntityFrameworkCore;
using SlotMachineApplication.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachineApplication.Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        // Creating Spin Tables on migration to MYSQL
        public DbSet<Spin> Spins { get; set; }
    }
}
