using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticInstallments.Models.Entities
{
    class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double ContractValue { get; set; }
        public List<Installment> Installments { get; set; }

        public Contract(int number, DateTime date, double contractValue)
        {
            Number = number;
            Date = date;
            ContractValue = contractValue;
            Installments = new List<Installment>();
        }

        public void AddInstallment(Installment installment)
        {
            Installments.Add(installment);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Installments.ForEach(installment => sb.AppendLine(installment.ToString()));
            return sb.ToString();
        }
    }
}