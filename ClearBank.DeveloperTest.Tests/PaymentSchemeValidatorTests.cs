using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests;

[TestFixture]
public class PaymentSchemeValidatorTests
{
    [Test]
    public void BacsPaymentSchemeValidator_ShouldReturnTrue_WhenAccountIsValid()
    {
        var account = new Account
        {
            AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
        };
        var request = new MakePaymentRequest();

        var validator = new BacsPaymentSchemeValidator();
        var result = validator.IsPaymentAllowed(account, request);

        Assert.That(result, Is.True);
    }

    [Test]
    public void BacsPaymentSchemeValidator_ShouldReturnFalse_WhenAccountIsNull()
    {
        var validator = new BacsPaymentSchemeValidator();
        var result = validator.IsPaymentAllowed(null, new MakePaymentRequest());

        Assert.That(result, Is.False);
    }

    [Test]
    public void FasterPaymentsSchemeValidator_ShouldReturnTrue_WhenBalanceIsEnough()
    {
        var account = new Account
        {
            AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
            Balance = 1000
        };
        var request = new MakePaymentRequest { Amount = 500 };

        var validator = new FasterPaymentSchemeValidator();
        var result = validator.IsPaymentAllowed(account, request);

        Assert.That(result, Is.True);
    }

    [Test]
    public void FasterPaymentsSchemeValidator_ShouldReturnFalse_WhenBalanceIsInsufficient()
    {
        var account = new Account
        {
            AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
            Balance = 100
        };
        var request = new MakePaymentRequest { Amount = 500 };

        var validator = new FasterPaymentSchemeValidator();
        var result = validator.IsPaymentAllowed(account, request);

        Assert.That(result, Is.False);
    }

    [Test]
    public void ChapsPaymentSchemeValidator_ShouldReturnTrue_WhenAccountIsLive()
    {
        var account = new Account
        {
            AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
            Status = AccountStatus.Live
        };
        var request = new MakePaymentRequest();

        var validator = new ChapsPaymentSchemeValidator();
        var result = validator.IsPaymentAllowed(account, request);

        Assert.That(result, Is.True);
    }

    [Test]
    public void ChapsPaymentSchemeValidator_ShouldReturnFalse_WhenAccountStatusIsNotLive()
    {
        var account = new Account
        {
            AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
            Status = AccountStatus.Disabled
        };
        var request = new MakePaymentRequest();

        var validator = new ChapsPaymentSchemeValidator();
        var result = validator.IsPaymentAllowed(account, request);

        Assert.That(result, Is.False);
    }
}
