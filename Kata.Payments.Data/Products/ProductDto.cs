using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kata.Payments.Data.Products
{
    [Table("Products")]
    public class ProductDto
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        public int ProductType { get; set; }

        public int Category { get; set; }
    }
}
