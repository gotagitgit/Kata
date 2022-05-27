using System;
using System.Collections.Generic;

namespace Kata.Payments.Rules.Models
{
    public sealed class Order
    {
        public Order(
            Guid id,
            PaymentType paymentType,
            OrderStatus orderStatus,
            decimal amountPaid,
            List<OrderItem> orderItems)
        {
            Id = id;
            PaymentType = paymentType;
            OrderStatus = orderStatus;
            AmountPaid = amountPaid;
            OrderItems = orderItems;
        }

        public Guid Id { get; }

        public PaymentType PaymentType { get; }

        public OrderStatus OrderStatus { get; }
        public decimal AmountPaid { get; }
        public List<OrderItem> OrderItems { get; }

        public Order WithOrderStatus(OrderStatus orderStatus)
        {
            return new Order(Id, PaymentType, orderStatus, AmountPaid, OrderItems);
        }
    }   
    
    public class OrderItem
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; }
        public int Quantity { get; }
    }

    public enum PaymentType
    {
        Check,
        CreditCard
    }

    public enum OrderStatus
    {
        New,
        Pending,
        Paid,
        PendingStock,
        ReadyToShip,
        Shipped,
        Completed
    }
}
