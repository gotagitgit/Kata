using System;

namespace Kata.Payments.Rules.Models
{
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
}
