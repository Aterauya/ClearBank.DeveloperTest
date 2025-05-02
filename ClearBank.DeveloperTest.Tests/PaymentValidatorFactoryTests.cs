using NUnit.Framework;
using ClearBank.DeveloperTest.Validators;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Tests
{
    [TestFixture]
    public class PaymentSchemeValidatorFactoryTests
    {
        private PaymentSchemeValidatorFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new PaymentSchemeValidatorFactory();
        }

        [Test]
        public void GetValidator_ShouldReturnBacsValidator_WhenPaymentSchemeIsBacs()
        {
            var validator = _factory.GetValidator(PaymentScheme.Bacs);
            Assert.That(validator, Is.TypeOf<BacsPaymentSchemeValidator>());
        }

        [Test]
        public void GetValidator_ShouldReturnFasterPaymentsValidator_WhenPaymentSchemeIsFasterPayments()
        {
            var validator = _factory.GetValidator(PaymentScheme.FasterPayments);
            Assert.That(validator, Is.TypeOf<FasterPaymentSchemeValidator>());
        }

        [Test]
        public void GetValidator_ShouldReturnChapsValidator_WhenPaymentSchemeIsChaps()
        {
            var validator = _factory.GetValidator(PaymentScheme.Chaps);
            Assert.That(validator, Is.TypeOf<ChapsPaymentSchemeValidator>());
        }

        [Test]
        public void GetValidator_ShouldReturnNull_WhenPaymentSchemeIsUnknown()
        {
            var validator = _factory.GetValidator((PaymentScheme)999);
            Assert.That(validator, Is.Null);
        }
    }
}
