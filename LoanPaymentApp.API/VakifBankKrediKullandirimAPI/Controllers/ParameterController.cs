using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VakifBankKrediKullandirimAPI.Interfaces;
using VakifBankKrediKullandirimAPI.Models;
using VakifBankKrediKullandirimAPI.Repository;

namespace VakifBankKrediKullandirimAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private readonly IParameterRepository _parameterRepository;

        public ParameterController(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        [HttpGet]
        [Route("GetParams")]
        public ActionResult<List<Parameter>> GetAllParams()
        {
            return Ok(_parameterRepository.GetAllParameters());
        }
    }
}
