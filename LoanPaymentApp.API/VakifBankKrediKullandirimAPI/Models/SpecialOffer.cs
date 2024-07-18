using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VakifBankKrediKullandirimAPI.Models.Category;

namespace VakifBankKrediKullandirimAPI.Models
{
    [Index(nameof(Code), IsUnique = true)]
    public class SpecialOffer
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [ForeignKey(nameof(ProductCategory))]
        public int ProductCategoryID { get; set; }
        public ProductCategory? ProductCategory { get; set; }
    }
}
