namespace Kata.SuperMarketCheckout.Stocks.Models
{
    public sealed class StockItem
    {
        public StockItem(Stock stock, double quantity)
        {
            Stock = stock;
            Quantity = quantity;
        }

        public Stock Stock { get; }

        public double Quantity { get; }

        public decimal ItemPrice => Stock.PriceScheme.ComputeCost(this);

        public StockItem WithQuantity(double quantity)
        {
            return new StockItem(Stock, quantity);
        }
    }
}
