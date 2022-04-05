using Kata.SupermarketPricing.Models.UOMs;

namespace Kata.SupermarketPricing.Models
{
    public sealed class ItemMeasure
    {
        public ItemMeasure(double quantity, UnitOfMeasure uom)
        {
            Quantity = quantity;
            Uom = uom;
        }

        public double Quantity { get; }
        public UnitOfMeasure Uom { get; }
    }
}
