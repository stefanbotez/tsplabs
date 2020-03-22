using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Configuration;

namespace CodeFirst.Models
{
    public partial class ModelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-0QEJPHH\\SQLEXPRESS; Database = CodeFirst; Trusted_Connection = True");
            //ChangeTracker.LazyLoadingEnabled = false;
        }
        



        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
    }
}
