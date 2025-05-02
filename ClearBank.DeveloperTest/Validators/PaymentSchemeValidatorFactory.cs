using System.Collections.Generic;
using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators
{
    public class PaymentSchemeValidatorFactory
    {
        private readonly Dictionary<PaymentScheme, IPaymentSchemeValidator> _validators;

        public PaymentSchemeValidatorFactory()
        {
            _validators = new Dictionary<PaymentScheme, IPaymentSchemeValidator>
        {
            { PaymentScheme.Bacs, new BacsPaymentSchemeValidator() },
            { PaymentScheme.FasterPayments, new FasterPaymentSchemeValidator() },
            { PaymentScheme.Chaps, new ChapsPaymentSchemeValidator() }
        };
        }

        public IPaymentSchemeValidator GetValidator(PaymentScheme scheme)
        {
            return _validators.TryGetValue(scheme, out var validator) ? validator : null;
        }
    }
}
