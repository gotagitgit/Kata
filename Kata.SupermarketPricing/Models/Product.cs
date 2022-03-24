namespace Kata.SupermarketPricing.Models
{
    public sealed class Product
    {
        public Product(string name, double price, IPriceScheme priceScheme)
        {
            Name = name;
            Price = price;
            PriceScheme = priceScheme;
        }

        public string Name { get; }

        public double Price { get; }

        public IPriceScheme PriceScheme { get; }


    }
}
