using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using System.Configuration;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var dataStore = DataStoreFactory.GetDataStore(ConfigurationManager.AppSettings["DataStoreType"]);
            var account = dataStore.GetAccount(request.DebtorAccountNumber);

            var factory = new PaymentSchemeValidatorFactory();
            var validator = factory.GetValidator(request.PaymentScheme);

            var result = new MakePaymentResult
            {
                Success = validator != null && validator.IsPaymentAllowed(account, request)
            };

            if (result.Success)
            {
                account.Balance -= request.Amount;

                dataStore.UpdateAccount(account);
            }

            return result;
        }
    }
}
