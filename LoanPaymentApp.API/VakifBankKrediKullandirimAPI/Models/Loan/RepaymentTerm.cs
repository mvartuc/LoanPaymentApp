using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VakifBankKrediKullandirimAPI.Helpers.CustomDateClasses;
using static VakifBankKrediKullandirimAPI.Helpers.Helpers;

namespace VakifBankKrediKullandirimAPI.Models.Loan
{
    [Index(nameof(Code), IsUnique = true)]
    public class RepaymentTerm
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = RandomCode();

        [ForeignKey(nameof(Year))]
        public int YearID { get; set; }
        public DatePart Year { get; set; } = new DatePart("Yıl", LOAN_YEAR_LIMIT);

        [ForeignKey(nameof(Month))]
        public int MonthID { get; set; }
        public DatePart Month { get; set; } = new DatePart("Ay", LOAN_YEAR_LIMIT* 12);
    }
}
