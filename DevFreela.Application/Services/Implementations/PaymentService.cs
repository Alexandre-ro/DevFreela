using DevFreela.CORE.Services;
using DevFreela.Payments.API.Models;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace DevFreela.Application.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _paymentsBaseUrl;

        public PaymentService(IHttpClientFactory httpClientFctory, IConfiguration configuration)
        {
            _httpClientFactory  = httpClientFctory;                
            _configuration      = configuration;
            _paymentsBaseUrl    = configuration.GetSection("Services:Payments").Value;
        }

        public async Task<bool> Proccess(PaymentInfoInputModel paymentDTO)
        {
            var url             = $"{_paymentsBaseUrl}/api/payments";
            var paymentInfoJson = JsonSerializer.Serialize(paymentDTO);

            var paymentInfoContent = new StringContent(
                    paymentInfoJson,
                    Encoding.UTF8,
                    "application/json"
                );

            var httpClient = _httpClientFactory.CreateClient("Payments");

            var response = await httpClient.PostAsync(url, paymentInfoContent);

            return response.IsSuccessStatusCode;
        }
    }
}
