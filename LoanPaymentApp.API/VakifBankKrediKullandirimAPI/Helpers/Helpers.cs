using VakifBankKrediKullandirimAPI.Helpers.CustomDateClasses;
using VakifBankKrediKullandirimAPI.Models.Loan;

namespace VakifBankKrediKullandirimAPI.Helpers
{
    public static class Helpers
    {
        private static Random random = new Random();
        public static int LOAN_YEAR_LIMIT { get; set; }
        public static int PERIOD_MONTH_LIMIT { get; set; }
        public static int CODE_LENGTH { get; set; }
        public static string CODE_CHARS { get; set; } = String.Empty;
        public static decimal DEFAULT_BSMV_PERCENTAGE { get; set; }

        public static string RandomString(int length)
        {
            return new string(Enumerable.Repeat(CODE_CHARS, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomCode()
        {
            return RandomString(CODE_LENGTH);
        }

        public static decimal RoundDownToTheNearestSecondDecimalDigit(decimal value)
        {
            return Math.Floor(value * 100m) / 100m;
        }
        public static decimal RoundUpToTheNearestSecondDecimalDigit(decimal value)
        {
            return Math.Ceiling(value * 100m) / 100m;
        }
        public static int GetPaymentInterval(RepaymentTerm repaymentTerm, DatePart period)
        {
            var totalMonths = GetTotalMonths(repaymentTerm);
            return (totalMonths / period.Value);
        }

        public static int GetTotalMonths(RepaymentTerm repaymentTerm)
        {
            var totalMonths = (repaymentTerm.Year.Value * 12) + repaymentTerm.Month.Value;
            return totalMonths;
        }

        public static DateTime GetEndDate(DateTime startDate, DatePart period)
        {
            var endDate = startDate.AddMonths(period.Value);
            return endDate;
        }
        public static decimal GetInstallmentInitialDebtAmount(decimal totalAmount, int paymentInterval)
        {
            var installmentDebtAmount = (totalAmount / paymentInterval);
            return RoundUpToTheNearestSecondDecimalDigit(installmentDebtAmount);
        }
        public static decimal GetInterestAmount(decimal amount, decimal interestPercentage, int monthCount)
        {
            var interestAmount = (amount * interestPercentage * (monthCount * 30) / 360);
            return Math.Round(interestAmount, 2);
        }

        public static decimal GetBsmvAmount(decimal bsmvPercentage, decimal interestAmount)
        {
            var bsmvAmount = interestAmount * bsmvPercentage;
            return Math.Round(bsmvAmount, 2);
        }

        public static decimal GetInstallmentAmountToBePaid(decimal totalInitialDebt, decimal interestPercentage, decimal bsmvPercentage, int paymentInterval)
        {
            var combinedPercentage
                = (interestPercentage + (interestPercentage * bsmvPercentage)) / 12m;
            var onePlusInterestToThePowerOfInterval
                = (decimal)Math.Pow((double)(1m + combinedPercentage), paymentInterval);
            var installmentAmountToBePaid
                = totalInitialDebt * ((combinedPercentage * onePlusInterestToThePowerOfInterval) / (onePlusInterestToThePowerOfInterval - 1m));
            return RoundUpToTheNearestSecondDecimalDigit(installmentAmountToBePaid);
        }
    }
}
