using System;

namespace Kata.Payments.Rules.Models
{
    public class Product
    {
        public Product(
            Guid id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}
