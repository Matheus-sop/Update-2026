using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

namespace WebApplication2.Models
{ 
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context(DbContextOptions<WebApplication2Context> options)
            : base(options)
        {
        }
        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<SalesRecord> SalesReecord { get; set; } = default!;

    }
}
