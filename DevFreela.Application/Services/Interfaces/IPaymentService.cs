using DevFreela.Payments.API.Models;

namespace DevFreela.CORE.Services
{
    public interface IPaymentService
    {
        Task<bool> Proccess(PaymentInfoInputModel paymentDTO);
    }
}
