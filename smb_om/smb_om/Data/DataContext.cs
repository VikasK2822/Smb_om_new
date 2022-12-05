using Microsoft.EntityFrameworkCore;
using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions <DataContext> options) : base(options)
        {


        }
        public DbSet<UserManager> UserManager { get; set; }
        public DbSet<OrderManagerLogin> OrderManagerLogin { get; set; }
        public DbSet<OrderMaster> OrderMaster { get; set; }
        public DbSet<productInformation> productInformation { get; set; }
        public DbSet<partner> partner { get; set; }
        public DbSet<Affiliate> affiliate { get; set; }
    }
}
