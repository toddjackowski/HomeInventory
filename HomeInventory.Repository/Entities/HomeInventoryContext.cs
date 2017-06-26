using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInventory.Repository.Entities
{
    public class HomeInventoryContext : DbContext
    {
        public HomeInventoryContext(): base("HomeInventory") 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HomeInventoryContext, Migrations.Configuration>("HomeInventory"));
        }

        public DbSet<Home> Homes { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<InventoryItemAttachment> InventoryItemAttachments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
