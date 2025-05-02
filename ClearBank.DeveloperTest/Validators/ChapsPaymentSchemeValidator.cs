using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators
{
    public class ChapsPaymentSchemeValidator : IPaymentSchemeValidator
    {
        public bool IsPaymentAllowed(Account account, MakePaymentRequest request)
        {
            return account != null
                && account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps)
                && account.Status == AccountStatus.Live;
        }
    }
}
