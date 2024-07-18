using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VakifBankKrediKullandirimAPI.Helpers.Helpers;

namespace VakifBankKrediKullandirimAPI.Models.Loan
{
    [Index(nameof(Code), IsUnique = true)]
    public class Installment
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; } = RandomCode();
        public int Order { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Precision(18, 2)]
        public decimal InitialDebtAmount { get; set; }

        [Precision(18, 2)]
        public decimal InterestAmount { get; set; }

        [Precision(18, 2)]
        public decimal BsmvAmount { get; set; }

        [Precision(18, 2)]
        public decimal AmountToBePaid { get; set; }

        [Precision(18, 2)]
        public decimal RemainingInitialDebtAmount { get; set; }

        [ForeignKey(nameof(PaymentPlan))]
        public int PaymentPlanID { get; set; }

    }
}
