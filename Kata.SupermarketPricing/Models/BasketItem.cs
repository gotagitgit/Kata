using Kata.SupermarketPricing.Models.UOMs;

namespace Kata.SupermarketPricing.Models
{
    public sealed class BasketItem
    {
        public BasketItem(Product product, double quantity, UnitOfMeasure uom)
        {
            Product = product;
            Quantity = quantity;
            Uom = uom;
        }

        public Product Product { get; }

        public double Quantity { get; }

        public UnitOfMeasure Uom { get; }

        public double ItemPrice => ComputeItemCost();

        private double ComputeItemCost()
        {
            var priceScheme = Product.PriceScheme;

            var itemMeasure = new ItemMeasure(Quantity, Uom);

            return priceScheme.ComputeItemPrice(Product, itemMeasure);
        }

        public BasketItem WithQuantity(double quantity)
        {
            return new BasketItem(Product, quantity + Quantity, Uom);
        }
    }
}
