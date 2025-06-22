using Employment_Counseling.Entities.Enums;

namespace Employment_Counseling.Services.Interfaces
{
    public interface IPayPalService
    {
        Task<PaymentStatus> VerifyPayment(string paymentId, Guid packageId);
    }
}