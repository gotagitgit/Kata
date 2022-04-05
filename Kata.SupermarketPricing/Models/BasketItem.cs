namespace Kata.SupermarketPricing.Models
{
    public sealed class BasketItem
    {
        public BasketItem(Product product, double quantity, double uomConversion)
        {
            Product = product;
            Quantity = quantity;
            UnitOfMeasureConversion = uomConversion;
        }

        public Product Product { get; }

        public double Quantity { get; }

        public double UnitOfMeasureConversion { get; }

        public double ItemPrice => ComputeItemCost();

        private double ComputeItemCost()
        {
            var priceScheme = Product.PriceScheme;

            if (string.IsNullOrEmpty(Product.UnitOfMeasure))
                return priceScheme.ComputeItemPrice(Product, Quantity);
            else
                return priceScheme.ComputeItemPriceWithUOM(Product, Quantity, UnitOfMeasureConversion);
        }

        public BasketItem WithQuantity(double quantity)
        {
            return new BasketItem(Product, quantity + Quantity, UnitOfMeasureConversion);
        }
    }
}
