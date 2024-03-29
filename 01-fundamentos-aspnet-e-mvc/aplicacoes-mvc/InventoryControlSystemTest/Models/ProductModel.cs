﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryControlSystemTest.Models
{
    public class ProductModel
    {
        [Key]
        public int IdProduct { get; set; }

        [Required, MaxLength(128)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        [ForeignKey("Category")]
        public int IdCategoria { get; set; }
        public CategoryModel Category { get; set; }

    }
}
