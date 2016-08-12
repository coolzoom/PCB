﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.Warehouse
{
    /// <summary>
    /// resistor, capacitor, varistor and etc
    /// </summary>
    [Table("Item", Schema="store")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string NameItem { get; set; }

        public virtual ICollection<Hanging> Hangings { get; set; }
        public virtual ICollection<SMD> SMDs { get; set; }
    }
}
