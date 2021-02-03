namespace AutomaticInstallments.Models.Services
{
    interface IOnlinePayment
    {
        double PaymentFee(double amount);
        double Interest(double amount, int months);
    }
}