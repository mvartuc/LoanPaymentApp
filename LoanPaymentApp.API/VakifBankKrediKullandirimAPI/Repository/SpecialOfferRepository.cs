using Microsoft.EntityFrameworkCore;
using VakifBankKrediKullandirimAPI.Data;
using VakifBankKrediKullandirimAPI.Interfaces;
using VakifBankKrediKullandirimAPI.Models;

namespace VakifBankKrediKullandirimAPI.Repository
{
    public class SpecialOfferRepository : ISpecialOfferRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryRepository _categoryRepository;

        public SpecialOfferRepository(ApplicationDbContext context, ICategoryRepository categoryRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<SpecialOffer>> GetAllSpecialOffersAsync()
        {
            return await _context.SpecialOffers.Include(o => o.ProductCategory).ToListAsync();
        }

        public async Task<SpecialOffer> GetSpecialOfferByCodeAsync(string code)
        {
            return await _context.SpecialOffers.Include(o => o.ProductCategory).Where(o => o.Code == code).FirstAsync();
        }

        public async Task<SpecialOffer> GetSpecialOfferByIdAsync(int id)
        {
            return await _context.SpecialOffers.Include(o => o.ProductCategory).Where(o => o.Id == id).FirstAsync();
        }

        public async Task<IEnumerable<SpecialOffer>> GetSpecialOffersByCategoryCodeAsync(string code)
        {
            var category = await _categoryRepository.GetCategoryByCodeAsync(code);
            return category.SpecialOffers.ToList();
        }
    }
}
