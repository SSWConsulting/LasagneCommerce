namespace Application.Common.Models;

public class PaymentResult
{
    public bool IsSuccessful { get; set; } = false;
    public Guid PaymentId { get; set; }
}
