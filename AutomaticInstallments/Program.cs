using System;
using System.Globalization;
using AutomaticInstallments.Models.Entities;
using AutomaticInstallments.Models.Services;

namespace AutomaticInstallments
{
    class Program
    {
        static readonly string errorMessage = "-- Please fill in again: --\n";
        static int ContractNumber()
        {
            Console.Write("Contract Identification Number: ");
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(errorMessage);
                return ContractNumber();
            }
        }

        static DateTime ContractDate()
        {
            Console.Write("Initial Date (dd/MM/yyyy)\n>> ");
            try
            {
                return DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(errorMessage);
                return ContractDate();
            }
        }

        static double ContractValue()
        {
            Console.Write("Contract Value $ ");
            try
            {
                return double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(errorMessage);
                return ContractValue();
            }
        }

        static int ContractInstallment()
        {
            Console.Write("Number of installments: ");
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(errorMessage);
                return ContractInstallment();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== Contract Data ===\n");

            int number = ContractNumber();

            DateTime date = ContractDate();

            double contractValue = ContractValue();

            Console.WriteLine("\n-- Currently the service hired by the company is Paypal, which applies simple interest of 1% on each installment plus 2% on the payment rate --\n");

            int months = ContractInstallment();

            Contract contract = new Contract(number, date, contractValue);

            Console.WriteLine("\n=== Payment Calculation for each Installment ===\n");

            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(contract, months);
            Console.WriteLine(contract);
        }
    }
}