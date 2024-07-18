using VakifBankKrediKullandirimAPI.Models;

namespace VakifBankKrediKullandirimAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> GetProductByCodeAsync(string code);
        Task<Product> GetEmptyProductAsync();
        Task<bool> SaveProductAsync(Product product);
    }
}
