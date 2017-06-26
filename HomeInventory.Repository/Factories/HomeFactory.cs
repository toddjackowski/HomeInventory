using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeInventory.Repository.Factories
{
    public class HomeFactory
    {
        private InventoryItemFactory itemFactory = new InventoryItemFactory();

        public HomeFactory()
        {
        }

        public DataObject.Home CreateHome(Entities.Home home)
        {
            return new DataObject.Home()
            {
                HomeId = home.HomeId,
                Name = home.Name,
                InventoryItems = home.InventoryItems.Select(i => itemFactory.CreateInventoryItem(i)).ToList()
            };
        }

        public Entities.Home CreateHome(DataObject.Home home)
        {
            return new Entities.Home()
            {
                HomeId = home.HomeId,
                Name = home.Name,
                InventoryItems = home.InventoryItems == null ? new List<Entities.InventoryItem>() : home.InventoryItems.Select(i => itemFactory.CreateInventoryItem(i)).ToList()
            };
        }
    }
}
