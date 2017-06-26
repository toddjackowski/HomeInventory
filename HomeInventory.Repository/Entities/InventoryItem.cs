using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;

namespace HomeInventory.Repository.Entities
{
    [Table("InventoryItem")]
    public class InventoryItem
    {
        [Key]
        public int InventoryItemId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string ModelNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatePurchased { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int HomeId { get; set; }
        
        public virtual Home Home { get; set; }

        public virtual List<InventoryItemAttachment> InventoryItemAttachments { get; set; }
    }
}
