namespace Kata.SupermarketPricing.Models
{
    public sealed class Item
    {
        public Item(Product product, double quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; }

        public double Quantity { get; }

        public double ComputeItemCost()
        {
            var priceScheme = Product.PriceScheme;

            return priceScheme.ComputeItemPrice(Product, Quantity);
        }
    }
}
