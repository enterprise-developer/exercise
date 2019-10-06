using System.Data.Entity;
using TestERP.Inventory.Entity;

namespace TestERP.Inventory.Context
{
    public class InventoryDbContext: DbContext
    {
        public InventoryDbContext():base("InventoryConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<InventoryDbContext>());
        }

        public IDbSet<Product> Products { get; set; }
    }
}
