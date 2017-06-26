using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInventory.Repository.Factories
{
    public class InventoryItemAttachmentFactory
    {
        public InventoryItemAttachmentFactory()
        {
            
        }

        public DataObject.InventoryItemAttachment CreateInventoryItemAttachment(Entities.InventoryItemAttachment inventoryItemAttachment)
        {
            return new DataObject.InventoryItemAttachment()
            {
                InventoryItemAttachmentId = inventoryItemAttachment.InventoryItemAttachmentId,
                Name = inventoryItemAttachment.Name,
                FileLocation = inventoryItemAttachment.FileLocation,
                InventoryItemId = inventoryItemAttachment.InventoryItemId
            };
        }

        public Entities.InventoryItemAttachment CreateInventoryItemAttachment(DataObject.InventoryItemAttachment inventoryItemAttachment)
        {
            return new Entities.InventoryItemAttachment()
            {
                InventoryItemAttachmentId = inventoryItemAttachment.InventoryItemAttachmentId,
                Name = inventoryItemAttachment.Name,
                FileLocation = inventoryItemAttachment.FileLocation,
                InventoryItemId = inventoryItemAttachment.InventoryItemId
            };
        }
    }
}
