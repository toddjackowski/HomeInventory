using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeInventory.DataObject
{
    public class Home
    {
        public int HomeId { get; set; }

        public string Name { get; set; }

        public ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
