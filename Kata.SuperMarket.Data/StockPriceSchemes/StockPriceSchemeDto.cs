using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kata.SuperMarket.Data.StockPriceSchemes
{
    [Table("StockPriceSchemes")]
    public class StockPriceSchemeDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public int PriceScheme { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "xml")]
        public string PriceSchemeDetail { get; set; }
    }
}
