using VakifBankKrediKullandirimAPI.Models;

namespace VakifBankKrediKullandirimAPI.Interfaces
{
    public interface IParameterRepository
    {
        Parameter GetParameterById(int id);
        Parameter GetParameterByCode(string code);
        IEnumerable<Parameter> GetAllParameters();
        IEnumerable<Parameter> GetParametersByGroupCode(string groupCode);
    }
}
