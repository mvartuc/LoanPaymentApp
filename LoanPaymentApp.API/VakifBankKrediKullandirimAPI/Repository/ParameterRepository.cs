using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VakifBankKrediKullandirimAPI.Data;
using VakifBankKrediKullandirimAPI.Interfaces;
using VakifBankKrediKullandirimAPI.Models;
using static VakifBankKrediKullandirimAPI.Helpers.Helpers;

namespace VakifBankKrediKullandirimAPI.Repository
{
    public class ParameterRepository : IParameterRepository
    {
        private readonly ApplicationDbContext _context;
        public IEnumerable<Parameter> Parameters { get; private set; } = new List<Parameter>();

        public ParameterRepository(ApplicationDbContext context)
        {
            _context = context;
            if (Parameters.IsNullOrEmpty())
            {
                this.Parameters = _context.Parameters.ToList();
            }

            SetCachedValues();
        }

        public void SetCachedValues()
        {
            LOAN_YEAR_LIMIT = GetIntFromParameter("VadeYilMaksimum");
            PERIOD_MONTH_LIMIT = GetIntFromParameter("PeriyotAyMaksimum");
            CODE_LENGTH = GetIntFromParameter("KodUzunluk");
            CODE_CHARS = GetStringFromParameter("KodKarakterIcerik");
            DEFAULT_BSMV_PERCENTAGE = GetDecimalFromParameter("BsmvDefault");
        }

        public int GetIntFromParameter(string groupCode)
        {
            var valueStr = GetStringFromParameter(groupCode);
            return Convert.ToInt32(valueStr);
        }
        public decimal GetDecimalFromParameter(string groupCode)
        {
            var valueStr = GetStringFromParameter(groupCode);
            return Convert.ToDecimal(valueStr);
        }
        public string GetStringFromParameter(string groupCode)
        {
            return GetParametersByGroupCode(groupCode).First().Description;
        }

        public IEnumerable<Parameter> GetAllParameters()
        {
            return this.Parameters;
        }

        public Parameter GetParameterByCode(string code)
        {
            return Parameters.Where(p => p.Code == code).First();
        }

        public Parameter GetParameterById(int id)
        {
            return Parameters.Where(p => p.Id == id).First();
        }

        public IEnumerable<Parameter> GetParametersByGroupCode(string groupCode)
        {
            return Parameters.Where(p => p.GroupCode == groupCode).ToList();
        }
    }
}
