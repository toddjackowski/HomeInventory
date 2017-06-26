using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInventory.DataObject
{
    public class InventoryItem
    {
        public int InventoryItemId { get; set; }

        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string ModelNumber { get; set; }

        public DateTime DatePurchased { get; set; }

        public decimal Price { get; set; }

        public int HomeId { get; set; }

        public ICollection<InventoryItemAttachment> InventoryItemAttachments { get; set; }
    }
}
