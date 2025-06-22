using Employment_Counseling.Data;
using Employment_Counseling.Entities.Enums;
using Employment_Counseling.Repositories.Interfaces;
using Employment_Counseling.Services.Interfaces;

namespace Employment_Counseling.Services
{
    public class PayPalService : IPayPalService
    {
        private readonly IPackageRepository _packageRepository;

        public PayPalService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<PaymentStatus> VerifyPayment(string paymentId, Guid packageId)
        {            
            var package = await _packageRepository.GetPackageByIdAsync(packageId);
            if (package == null)
                return PaymentStatus.InValid;

            // כאן בעתיד לבדוק סכום/פרטי תשלום אמיתי מול PayPal

            return PaymentStatus.Paid;
        }
    }

}
