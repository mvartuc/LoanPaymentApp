using Microsoft.EntityFrameworkCore;
using VakifBankKrediKullandirimAPI.Data;
using VakifBankKrediKullandirimAPI.Interfaces;
using VakifBankKrediKullandirimAPI.Models.Category;

namespace VakifBankKrediKullandirimAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductParentCategory>> GetAllParentCategoriesAsync()
        {
            return await _context.ParentCategories.Include(c => c.ChildCategories).ThenInclude(c => c.SpecialOffers).ToListAsync();
        }
        public async Task<ProductParentCategory> GetParentCategoryByIdAsync(int id)
        {
            return await _context.ParentCategories.Include(x => x.ChildCategories).ThenInclude(c => c.SpecialOffers).Where(x => x.Id == id).FirstAsync();
        }
        public async Task<ProductParentCategory> GetParentCategoryByCodeAsync(string code)
        {
            return await _context.ParentCategories.Include(x => x.ChildCategories).Where(x => x.Code == code).FirstAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetAllChildrenFromParentCategoryByIdAsync(int id)
        {
            var parent = await GetParentCategoryByIdAsync(id);
            return parent.ChildCategories.ToList();
        }
        public async Task<ProductCategory> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.Include(c => c.SpecialOffers).Where(x => x.Id == id).FirstAsync();
        }
        public async Task<ProductCategory> GetCategoryByCodeAsync(string code)
        {
            return await _context.Categories.Include(c => c.SpecialOffers).Where(x => x.Code == code).FirstAsync();
        }
    }
}
