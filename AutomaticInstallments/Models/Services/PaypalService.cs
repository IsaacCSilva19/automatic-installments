namespace AutomaticInstallments.Models.Services
{
    struct PaypalService : IOnlinePayment
    {
        private const double FeePercentage = 0.02;
        private const double MonthlyInterest = 0.01;

        public double PaymentFee(double amount)
        {
            return amount * FeePercentage;
        }

        public double Interest(double amount, int months)
        {
            return amount * months * MonthlyInterest;
        }
    }
}