using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;

namespace HomeInventory.Repository.Entities
{
    [Table("Home")]
    public class Home
    {
        [Key]
        public int HomeId  { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual List<InventoryItem> InventoryItems { get; set; }

    }
}
