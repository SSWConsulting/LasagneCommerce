using Application.Common.Abstractions;
using Application.Common.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Infrastructure.Servicees;

public class PaymentService : IPaymentService
{
    public async Task<PaymentResult> MakePayment(string cardNumber, string cardExpiry, string cvv)
    {
        // TODO: use IHttpClientFactory
        var httpClient = new HttpClient();

        // TODO: create a type for this
        var requestBody = new
        {
            cardNumber,
            cardExpiry,
            cvv
        };

        var response = await httpClient.PostAsJsonAsync("https://spaghettipayments.com/api/payment", requestBody);

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<PaymentResult>(responseBody);

            if (result is not null)
            {
                return result;
            }
        }

        return new PaymentResult();
    }
}
