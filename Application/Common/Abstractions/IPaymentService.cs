using Application.Common.Models;

namespace Application.Common.Abstractions;

public interface IPaymentService
{
    Task<PaymentResult> MakePayment(string cardNumber, string cardExpiry, string cvv);
}
