namespace Kata.SupermarketPricing.Models
{
    public sealed class BasketItem
    {
        public BasketItem(Product product, double quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; }

        public double Quantity { get; }

        public double ItemPrice => ComputeItemCost();

        private double ComputeItemCost()
        {
            var priceScheme = Product.PriceScheme;

            return priceScheme.ComputeItemPrice(Product, Quantity);
        }

        public BasketItem WithQuantity(double quantity)
        {
            return new BasketItem(Product, quantity + Quantity);
        }
    }
}
