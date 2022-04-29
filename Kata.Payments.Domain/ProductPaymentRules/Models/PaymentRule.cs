using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Payments.Domain.ProductPaymentRules.Models
{
    public enum PaymentRule
    {
        NewMemberShipRule = 1,
        UpgradeMemberShipRule = 2,
        PackingSlip = 3
    }
}
