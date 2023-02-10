using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace VakifBankKrediKullandirimAPI.Models
{
    public class Parameter
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;
        public string GroupCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
