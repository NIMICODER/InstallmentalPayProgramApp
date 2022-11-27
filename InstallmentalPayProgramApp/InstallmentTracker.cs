using InstallmentalPayProgramApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace InstallmentalPayProgramApp
{
    public class InstallmentTracker
    {
        public string _CustomerName { get; set; }
        public string _ProductName { get; set; }
        private decimal _ProductPrice { get; set; }
        public double _PaymentBalance { get; set; }
        internal DateTime _PurchaseDate { get; set; }
        internal InstallmentalOption _RepaymentPlan { get; set; }
        
        public double _InstallmentalAmount { get; set; }
        
        
        public DateTime NextDueDate { get; set; }
        
        public int RepaymentTimes { get; set; }
       // public InstallmentalOption InstallmentalOption { get; internal set; }

        public InstallmentTracker()
        {

        }

        internal InstallmentTracker GetCustomerInfo()
        {
            InstallmentTracker customer = new();
            try
            {
                Console.WriteLine("Enter Customer Full Name");
                string fullName = Console.ReadLine();
                Console.WriteLine("Select Installment Option. You will be making payment five times!!");
                Console.WriteLine("\n 1 : Daily Plan \n 2 : Weelkly Plan \n 3 : Biweekly Plan " +
                    "\n 4 : Monthly Plan \n 5 : Mid-Year Plan \n 6 : Yearly Plan ");
                int paymentOption = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Product Name");
                string description = Console.ReadLine();
                Console.WriteLine("Enter Product Price");
                double amount = double.Parse(Console.ReadLine());


                _CustomerName = fullName;
                _RepaymentPlan = (InstallmentalOption)GetOption(paymentOption);
                _ProductPrice = (decimal)amount;
                _PaymentBalance = amount;
                _InstallmentalAmount = amount / 5;
                _PurchaseDate = DateTime.Now;
                _ProductName = description;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                GetCustomerInfo();

            }

            Console.WriteLine($"{_CustomerName} has succesfully activated {_RepaymentPlan} installmental Payment Option For {_ProductName}");

            return customer;
        }
        public static InstallmentalOption? GetOption(int paymentOption)
        {
            switch (paymentOption)
            {
                case 1:
                    return InstallmentalOption.DailyPlan;

                case 2:
                    return InstallmentalOption.WeeklyPlan;

                case 3:
                    return InstallmentalOption.BiWeeklyPlan;

                case 4:
                    return InstallmentalOption.MonthlyPlan;

                case 5:
                    return InstallmentalOption.MidYearPlan;

                case 6:
                    return InstallmentalOption.YearlyPlan;

                default:
                    return null;

            }
        }
    }
}
