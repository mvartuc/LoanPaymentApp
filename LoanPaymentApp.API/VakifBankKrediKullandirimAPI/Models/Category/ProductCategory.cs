using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VakifBankKrediKullandirimAPI.Models.Category
{
    [Index(nameof(Code), IsUnique = true)]
    public class ProductCategory
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [ForeignKey(nameof(ProductParentCategory))]
        public int ParentCategoryID { get; set; }

        [JsonIgnore]
        public ProductParentCategory? ParentCategory { get; set; }
        public ICollection<SpecialOffer> SpecialOffers { get; set; }
    }
}
