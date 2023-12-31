﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.API.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public ProductType Type { get; set; }

        [Required]
        public long Value { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
