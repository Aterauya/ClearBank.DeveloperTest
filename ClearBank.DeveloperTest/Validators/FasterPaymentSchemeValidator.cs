using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators
{
    public class FasterPaymentSchemeValidator : IPaymentSchemeValidator
    {
        public bool IsPaymentAllowed(Account account, MakePaymentRequest request)
        {
            return account != null
                && account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments)
                && account.Balance >= request.Amount;
        }
    }
}
