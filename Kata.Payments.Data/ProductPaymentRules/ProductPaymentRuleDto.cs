using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kata.Payments.Data.ProductPaymentRules
{
    [Table("ProductPaymentRules")]
    public class ProductPaymentRuleDto
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Products")]
        public Guid ProductId { get; set; }

        public int PaymentRule { get; set; }
    }
}
