using VakifBankKrediKullandirimAPI.Models;

namespace VakifBankKrediKullandirimAPI.Interfaces
{
    public interface ISpecialOfferRepository
    {
        Task<SpecialOffer> GetSpecialOfferByIdAsync(int id);
        Task<SpecialOffer> GetSpecialOfferByCodeAsync(string code);
        Task<IEnumerable<SpecialOffer>> GetAllSpecialOffersAsync();
        Task<IEnumerable<SpecialOffer>> GetSpecialOffersByCategoryCodeAsync(string code);
    }
}
