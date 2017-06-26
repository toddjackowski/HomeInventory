using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeInventory.Repository.Entities;

namespace HomeInventory.Repository.Factories
{
    public class InventoryItemFactory
    {
        private InventoryItemAttachmentFactory attachmentFactory = new InventoryItemAttachmentFactory();

        public InventoryItemFactory()
        {
                
        }

        public DataObject.InventoryItem CreateInventoryItem(Entities.InventoryItem inventoryItem)
        {
            return new DataObject.InventoryItem()
            {
                InventoryItemId = inventoryItem.InventoryItemId,
                Name = inventoryItem.Name,
                SerialNumber = inventoryItem.SerialNumber,
                ModelNumber = inventoryItem.ModelNumber,
                DatePurchased = inventoryItem.DatePurchased,
                Price = inventoryItem.Price,
                HomeId = inventoryItem.HomeId,
                InventoryItemAttachments = inventoryItem.InventoryItemAttachments.Select(i => attachmentFactory.CreateInventoryItemAttachment(i)).ToList()
            };
        }

        public Entities.InventoryItem CreateInventoryItem(DataObject.InventoryItem inventoryItem)
        {
            return new Entities.InventoryItem()
            {
                InventoryItemId = inventoryItem.InventoryItemId,
                Name = inventoryItem.Name,
                SerialNumber = inventoryItem.SerialNumber,
                ModelNumber = inventoryItem.ModelNumber,
                DatePurchased = inventoryItem.DatePurchased,
                Price = inventoryItem.Price,
                HomeId = inventoryItem.HomeId,
                InventoryItemAttachments = inventoryItem.InventoryItemAttachments == null ? new List<InventoryItemAttachment>() : inventoryItem.InventoryItemAttachments.Select(i => attachmentFactory.CreateInventoryItemAttachment(i)).ToList()
            };
        }
    }
}
