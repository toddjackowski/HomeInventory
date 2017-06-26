using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInventory.DataObject
{
    public class InventoryItemAttachment
    {
        public int InventoryItemAttachmentId { get; set; }

        public string Name { get; set; }

        public string FileLocation { get; set; }

        public int InventoryItemId { get; set; }
    }
}
