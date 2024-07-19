using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VakifBankKrediKullandirimAPI.Interfaces;
using VakifBankKrediKullandirimAPI.Models.Category;
using VakifBankKrediKullandirimAPI.Models.Loan;
using VakifBankKrediKullandirimAPI.Repository;

namespace VakifBankKrediKullandirimAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentPlanController : ControllerBase
    {
        private readonly IPaymentPlanRepository _paymentPlanRepository;

        public PaymentPlanController(IPaymentPlanRepository paymentPlanRepository)
        {
            _paymentPlanRepository = paymentPlanRepository;
        }

        [HttpPost]
        [Route("GenerateInstallments")]
        public async Task<ActionResult<PaymentPlan>> GenerateInstallments([FromBody] PaymentPlan paymentPlan)
        {
            await paymentPlan.GenerateInstallmentsAsync();
            return Ok(paymentPlan);
        }
    }
}
