using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kata.SuperMarket.Data.Stocks
{
    [Table("Stocks")]
    public class StockDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Uom { get; set; }
    }
}
