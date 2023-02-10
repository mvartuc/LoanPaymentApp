using VakifBankKrediKullandirimAPI.Data;
using VakifBankKrediKullandirimAPI.Helpers.CustomDateClasses;
using VakifBankKrediKullandirimAPI.Interfaces;
using VakifBankKrediKullandirimAPI.Models.Loan;
using static VakifBankKrediKullandirimAPI.Helpers.Helpers;

namespace VakifBankKrediKullandirimAPI.Repository
{
    public class PaymentPlanRepository : IPaymentPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentPlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<PaymentPlan>> GetAllPaymentPlansAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PaymentPlan> GetPaymentPlanByCodeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentPlan> GetPaymentPlanByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
