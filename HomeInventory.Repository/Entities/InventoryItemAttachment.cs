using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;

namespace HomeInventory.Repository.Entities
{
    public class InventoryItemAttachment
    {
        [Key]
        public int InventoryItemAttachmentId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string FileLocation { get; set; }

        public int InventoryItemId { get; set; }

        public virtual InventoryItem InventoryItem { get; set; }
    }
}
