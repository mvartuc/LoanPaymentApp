using VakifBankKrediKullandirimAPI.Models.Category;

namespace VakifBankKrediKullandirimAPI.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ProductParentCategory> GetParentCategoryByIdAsync(int id);
        Task<ProductParentCategory> GetParentCategoryByCodeAsync(string code);

        Task<ProductCategory> GetCategoryByIdAsync(int id);
        Task<ProductCategory> GetCategoryByCodeAsync(string code);

        Task<IEnumerable<ProductCategory>> GetAllChildrenFromParentCategoryByIdAsync(int id);

        Task<IEnumerable<ProductParentCategory>> GetAllParentCategoriesAsync();
    }
}
