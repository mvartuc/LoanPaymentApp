using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using VakifBankKrediKullandirimAPI.Models.Category;
using VakifBankKrediKullandirimAPI.Models.Loan;
using static VakifBankKrediKullandirimAPI.Helpers.Helpers;

namespace VakifBankKrediKullandirimAPI.Models
{
    [Index(nameof(Code), IsUnique = true)]
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = RandomCode();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [ForeignKey(nameof(ProductCategory))]
        public int ProductCategoryID { get; set; }
        public ProductCategory? Category { get; set; }

        [ForeignKey(nameof(SpecialOffer))]
        public int? SpecialOfferID { get; set; }
        public SpecialOffer? SpecialOffer { get; set; }
        public string UsageTypeCode { get; set; } = string.Empty;
        public PaymentPlan PaymentPlan { get; set; } = new();
    }
}
