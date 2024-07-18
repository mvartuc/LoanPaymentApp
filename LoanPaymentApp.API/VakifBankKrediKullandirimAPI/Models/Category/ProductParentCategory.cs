
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VakifBankKrediKullandirimAPI.Models.Category
{
    [Index(nameof(Code), IsUnique = true)]
    public class ProductParentCategory
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<ProductCategory> ChildCategories { get; set; }
    }
}
