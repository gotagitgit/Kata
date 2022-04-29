using System;
using System.Collections.Generic;
using Kata.Payments.Domain.Payments.Services;

namespace Kata.Payments.Domain.Payments.Models
{
    public sealed class Product
    {
        public Product(
            Guid id,
            string name,
            ProductType productType,
            ProductCategory category,
            List<PaymentRule> paymentRules)
        {
            Id = id;
            Name = name;
            ProductType = productType;
            Category = category;
            PaymentRules = paymentRules;
        }

        public Guid Id { get; }
        public string Name { get; }
        public ProductType ProductType { get; }
        public ProductCategory Category { get; }
        public List<PaymentRule> PaymentRules { get; }
    }

    public enum ProductType
    {
        Physical = 1,
        NonPhysical = 2       
    }

    public enum ProductCategory
    {
        Generic = 0,
        Book = 1,
        Membership = 2,
        Video = 3,
    }

    public enum PaymentRule
    {
        NewMemberShipRule = 1,
        UpgradeMemberShipRule = 2,
        PackingSlip = 3
    }

    public sealed class BookPaymentRule
    {
        public BookPaymentRule(List<Product> products)
        {
            Products = products;
        }

        public List<Product> Products { get; }
    }

    public interface IPaymentRule
    {
        PaymentRule PaymentRule { get; }

        void ExecuteRule(Product product);
    }

    public sealed class MembershipPaymentRule : IPaymentRule
    {
        public PaymentRule PaymentRule => PaymentRule.NewMemberShipRule;

        public void ExecuteRule(Product product)
        {
        }
    }

    public sealed class MembershipUpgradePaymentRule : IPaymentRule
    {
        public PaymentRule PaymentRule => PaymentRule.UpgradeMemberShipRule;

        public void ExecuteRule(Product product)
        {            
        }
    }

    public sealed class PackingSlipPaymentRule : IPaymentRule
    {
        private readonly IShippingService _shippingService;

        public PackingSlipPaymentRule(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        public PaymentRule PaymentRule => PaymentRule.PackingSlip;

        public void ExecuteRule(Product product)
        {
            _shippingService.ProcessShipping(product);
        }
    }
}
