using Microsoft.EntityFrameworkCore;
using VakifBankKrediKullandirimAPI.Data;
using VakifBankKrediKullandirimAPI.Interfaces;
using VakifBankKrediKullandirimAPI.Models;

namespace VakifBankKrediKullandirimAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> GetEmptyProductAsync()
        {
            return await Task.Run(() => new Product());
        }

        public Task<Product> GetProductByCodeAsync(string code)
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.PaymentPlan)
                    .ThenInclude(plan => plan.RepaymentTerm)
                        .ThenInclude(term => term.Month)
                .Include(p => p.PaymentPlan)
                    .ThenInclude(plan => plan.RepaymentTerm)
                        .ThenInclude(term => term.Year)
                .Include(p => p.PaymentPlan)
                    .ThenInclude(plan => plan.Period)
                .Where(p => p.Code == code)
                .FirstAsync();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            return _context.Products.Where(p => p.Id == id).FirstAsync();
        }

        public async Task<bool> SaveProductAsync(Product product)
        {
            product.ProductCategoryID = product.Category.Id;
            product.Category = null;
            product.SpecialOfferID = product.SpecialOffer.Id;
            product.SpecialOffer = null;
            await product.PaymentPlan.GenerateInstallmentsAsync();
            await _context.Products.AddAsync(product);
            var changedCount = await _context.SaveChangesAsync();
            return changedCount > 0;
        }
    }
}
