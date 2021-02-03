using System;
using AutomaticInstallments.Models.Entities;

namespace AutomaticInstallments.Models.Services
{
    class ContractService
    {
        private readonly IOnlinePayment _onlinePayment;

        public ContractService(IOnlinePayment onlinePayment)
        {
            _onlinePayment = onlinePayment ?? throw new ArgumentNullException(nameof(onlinePayment));
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.ContractValue / months;

            for (int j = 1; j <= months; j++)
            {
                DateTime dueDate = contract.Date.AddMonths(j);

                double updateQuota = basicQuota + _onlinePayment.Interest(basicQuota, j);
                double fullQuota = updateQuota + _onlinePayment.PaymentFee(updateQuota);

                contract.AddInstallment(new Installment(dueDate, fullQuota));
            }
        }
    }
}