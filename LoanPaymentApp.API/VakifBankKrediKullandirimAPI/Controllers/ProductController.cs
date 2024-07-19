using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VakifBankKrediKullandirimAPI.Interfaces;
using VakifBankKrediKullandirimAPI.Models;
using VakifBankKrediKullandirimAPI.Models.Loan;
using VakifBankKrediKullandirimAPI.Repository;

namespace VakifBankKrediKullandirimAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("GetEmptyProduct")]
        public async Task<ActionResult<Product>> GetEmptyProductAsync()
        {
            return Ok(await _productRepository.GetEmptyProductAsync());
        }

        [HttpPost]
        [Route("SaveProduct")]
        public async Task<ActionResult<Product>> SaveProductAsync([FromBody] Product product)
        {
            var isSaved = await _productRepository.SaveProductAsync(product);
            if (isSaved)
            {
                return Ok(await _productRepository.GetProductByCodeAsync(product.Code));
            }
            return NotFound();
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
