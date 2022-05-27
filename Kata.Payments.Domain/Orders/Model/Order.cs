using System;
using System.Collections.Immutable;
using Kata.Payments.Domain.Products.Models;

namespace Kata.Payments.Domain.Orders.Model
{
    public sealed class Order
    {
        public Order(
            Guid id,
            PaymentType paymentType,
            OrderStatus orderStatus,
            decimal amountPaid,
            ImmutableList<Product> products)
        {
            Id = id;
            PaymentType = paymentType;
            OrderStatus = orderStatus;
            AmountPaid = amountPaid;
            Products = products;
        }

        public Guid Id { get; }

        public PaymentType PaymentType { get; }

        public OrderStatus OrderStatus { get; }
        public decimal AmountPaid { get; }
        public ImmutableList<Product> Products { get; }
    }

    public sealed class Customer
    {
        public Customer(Guid id, string name, bool hasCreditAccount)
        {
            Id = id;
            Name = name;
            HasCreditAccount = hasCreditAccount;
        }

        public Guid Id { get; }

        public string Name { get; }

        public bool HasCreditAccount { get; }
    }

    public enum PaymentType
    {
        Check,
        CreditCard
    }

    public enum OrderStatus
    {
        Pending,
        Paid,
        PendingStock,
        ReadyToShip,
        Shipped,        
        Completed
    }
}
