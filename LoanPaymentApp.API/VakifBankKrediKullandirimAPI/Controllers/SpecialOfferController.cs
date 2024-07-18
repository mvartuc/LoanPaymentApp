using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VakifBankKrediKullandirimAPI.Interfaces;
using VakifBankKrediKullandirimAPI.Models;

namespace VakifBankKrediKullandirimAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {
        private readonly ISpecialOfferRepository _specialOfferRepository;

        public SpecialOfferController(ISpecialOfferRepository specialOfferRepository)
        {
            _specialOfferRepository = specialOfferRepository;
        }


        [HttpGet]
        [Route("GetOffers")]
        public async Task<ActionResult<List<SpecialOffer>>> GetSpecialOffers(string categoryCode)
        {
            return Ok(await _specialOfferRepository.GetSpecialOffersByCategoryCodeAsync(categoryCode));
        }
    }
}
