using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using VakifBankKrediKullandirimAPI.Models;
using VakifBankKrediKullandirimAPI.Models.Category;
using VakifBankKrediKullandirimAPI.Models.Loan;

namespace VakifBankKrediKullandirimAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductParentCategory> ParentCategories { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<SpecialOffer> SpecialOffers { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<PaymentPlan> PaymentPlans { get; set; }
    }

}
