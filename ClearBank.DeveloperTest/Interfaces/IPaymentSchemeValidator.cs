using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Interfaces
{
    public interface IPaymentSchemeValidator
    {
        bool IsPaymentAllowed(Account account, MakePaymentRequest request);
    }
}
