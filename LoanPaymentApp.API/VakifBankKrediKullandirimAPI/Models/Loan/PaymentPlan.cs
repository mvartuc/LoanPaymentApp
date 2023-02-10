using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VakifBankKrediKullandirimAPI.Helpers.CustomDateClasses;
using VakifBankKrediKullandirimAPI.Interfaces;
using VakifBankKrediKullandirimAPI.Repository;
using static VakifBankKrediKullandirimAPI.Helpers.Helpers;


namespace VakifBankKrediKullandirimAPI.Models.Loan
{
    [Index(nameof(Code), IsUnique = true)]
    public class PaymentPlan
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = RandomCode();

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        [Precision(18, 2)]
        public decimal TotalInitialDebtAmount { get; set; }

        [Precision(5, 5)]
        public decimal InterestPercentage { get; set; }

        [Precision(5, 2)]
        public decimal BsmvPercentageDisplayValue { get; set; } = DEFAULT_BSMV_PERCENTAGE;

        [Precision(5, 5)]
        public decimal BsmvPercentage { get => (this.BsmvPercentageDisplayValue / 100m); }
        public DateTime FirstPaymentDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastPaymentDate { get; set; }

        [ForeignKey(nameof(RepaymentTerm))]
        public int RepaymentTermID { get; set; }
        public RepaymentTerm RepaymentTerm { get; set; } = new RepaymentTerm();
        public DatePart Period { get; set; } = new DatePart("Ay", PERIOD_MONTH_LIMIT);

        public string InstallmentTypeCode { get; set; } = String.Empty;
        public ICollection<Installment>? Installments { get; set; }

        [Precision(2, 2)]
        public decimal CrumbAmount { get; set; }

        [Precision(18, 2)]
        public decimal TotalInterestAmount { get; set; }

        [Precision(18, 2)]
        public decimal TotalBsmvAmount { get; set; }

        [Precision(18, 2)]
        public decimal TotalAmountToBePaid { get; set; }

        public async Task<IEnumerable<Installment>> GenerateInstallmentsAsync()
        {
            List<Installment> generatedInstallments = new List<Installment>();
            var paymentInterval = GetPaymentInterval(this.RepaymentTerm, this.Period);
            var installmentStartDate = this.FirstPaymentDate;
            var remainingTotalAmount = this.TotalInitialDebtAmount;

            await Task.Run(() =>
            {
                decimal initialDebtAmount = 0, amountToBePaid = 0, bsmvAmount = 0;
                for (var i = 1; i <= paymentInterval; i++)
                {
                    var interestAmount = GetInterestAmount(remainingTotalAmount, this.InterestPercentage, this.Period.Value);
                    this.TotalInterestAmount += interestAmount;
                    if (i == paymentInterval)
                        bsmvAmount = GetBsmvAmount(this.BsmvPercentage, Math.Floor(this.TotalInterestAmount * 10m)/10m) - this.TotalBsmvAmount;
                    else
                        bsmvAmount = GetBsmvAmount(this.BsmvPercentage, interestAmount);
                    this.TotalBsmvAmount += bsmvAmount;

                    // Esit Ana Para
                    if (this.InstallmentTypeCode == "0")
                    {
                        initialDebtAmount = GetInstallmentInitialDebtAmount(this.TotalInitialDebtAmount, paymentInterval);
                        if (i == paymentInterval)
                        {
                            initialDebtAmount += remainingTotalAmount - initialDebtAmount;
                        }
                        amountToBePaid = initialDebtAmount + interestAmount + bsmvAmount;
                    }
                    // Esit Taksit
                    else if (this.InstallmentTypeCode == "1")
                    {
                        amountToBePaid = GetInstallmentAmountToBePaid(this.TotalInitialDebtAmount, this.InterestPercentage, this.BsmvPercentage, paymentInterval);
                        initialDebtAmount = amountToBePaid - interestAmount - bsmvAmount;
                        if (i == paymentInterval)
                        {
                            initialDebtAmount += remainingTotalAmount - initialDebtAmount;
                            amountToBePaid = initialDebtAmount + interestAmount + bsmvAmount;
                        }
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }

                    this.TotalAmountToBePaid += amountToBePaid;
                    var installmentEndDate = GetEndDate(installmentStartDate, this.Period);

                    var installment = new Installment()
                    {
                        Order = i,
                        StartDate = installmentStartDate,
                        EndDate = installmentEndDate,
                        InitialDebtAmount = initialDebtAmount,
                        InterestAmount = interestAmount,
                        BsmvAmount = bsmvAmount,
                        AmountToBePaid = amountToBePaid,
                        PaymentPlanID = this.Id
                    };

                    generatedInstallments.Add(installment);

                    installmentStartDate = installmentEndDate;
                    remainingTotalAmount -= initialDebtAmount;
                    installment.RemainingInitialDebtAmount = remainingTotalAmount;
                }
            });
            this.CrumbAmount = remainingTotalAmount;
            this.LastPaymentDate = installmentStartDate;
            this.Installments = generatedInstallments;
            return generatedInstallments;
        }

        //public void RedistributeCrumbs()
        //{
        //    var lastInstallment = this.Installments.Last();
        //    lastInstallment.InitialDebtAmount += this.CrumbAmount;
        //    this.CrumbAmount = 0;
        //}
    }
}
