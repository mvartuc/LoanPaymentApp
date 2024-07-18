using VakifBankKrediKullandirimAPI.Models;
using VakifBankKrediKullandirimAPI.Models.Loan;

namespace VakifBankKrediKullandirimAPI.Interfaces
{
    public interface IPaymentPlanRepository
    {
        Task<PaymentPlan> GetPaymentPlanByIdAsync(int id);
        Task<PaymentPlan> GetPaymentPlanByCodeAsync(int id);
        Task<IEnumerable<PaymentPlan>> GetAllPaymentPlansAsync();
        //Task<IEnumerable<Installment>> GenerateInstallmentsFromPlanAsync(PaymentPlan paymentPlan);
    }
}
