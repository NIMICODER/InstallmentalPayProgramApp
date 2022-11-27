using InstallmentalPayProgramApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallmentalPayProgramApp
{
    public class CustomerRepaymentPlanRecords
    {
        InstallmentTracker customer = new();
        List<InstallmentTracker> customersList = new();

        public void InitializeApp()
        {
            try
            {
                Console.WriteLine("\nWelcome to Mr Buhari's Customer Register \n Please Select an Option?");
                Console.WriteLine($"\n 1 : Register new Customer \n 2 : View Customers List \n 3 : Add new Payment  \n 4 : CheckOut");
                int option = int.Parse(Console.ReadLine());


                switch (option)
                {
                    case 1:
                        Console.WriteLine();
                        customersList.Add(customer.GetCustomerInfo());
                        InitializeApp();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Customers details");
                        DisplayCustomersOwing();
                        InitializeApp();
                        break;
                    case 3:
                        Console.Clear();
                        UpdatePaymentList();
                        InitializeApp();
                        break;
                    case 4:
                        Environment.Exit(0000);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        InitializeApp();
                        break;

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                InitializeApp();
            }
        }
        internal InstallmentTracker? GetCustomers()
        {
            Console.WriteLine("Enter Debtor's Full Name");
            string fullName = Console.ReadLine().ToLower();
            InstallmentTracker currentcustomer = null;
            for (int i = 0; i < customersList.Count; i++)
            {
                if (customersList[i]._CustomerName.ToLower() == fullName)
                {
                    currentcustomer = customersList[i];
                }
                else
                {
                    return null;
                }
            }
            return currentcustomer;
        }

        internal void UpdatePaymentList()
        {

            Console.WriteLine("Add Payment To Repayment List");
            InstallmentTracker? customerowing = GetCustomers();
            //hey check here
            if (customerowing != null && customerowing.RepaymentTimes < (int)EnumDuration.InstallmentDuration.InstallmentPeriod)
            {
                switch (customerowing._RepaymentPlan)
                {
                    case InstallmentalOption.DailyPlan:
                        customerowing.NextDueDate = DateTime.Now.AddDays(1);
                        break;
                    case InstallmentalOption.WeeklyPlan:
                        customerowing.NextDueDate = DateTime.Now.AddDays(7);
                        break;
                    case InstallmentalOption.BiWeeklyPlan:
                        customerowing.NextDueDate = DateTime.Now.AddDays(14);
                        break;
                    case InstallmentalOption.MonthlyPlan:
                        customerowing.NextDueDate = DateTime.Now.AddMonths(1);
                        break;
                    case InstallmentalOption.MidYearPlan:
                        customerowing.NextDueDate = DateTime.Now.AddMonths(6);
                        break;
                    case InstallmentalOption.YearlyPlan:
                        customerowing.NextDueDate = DateTime.Now.AddYears(1);
                        break;
                    default:
                        break;
                }
                customerowing._PaymentBalance -= customer._InstallmentalAmount;
                customerowing.RepaymentTimes += 1;

                Console.WriteLine($" {customerowing._CustomerName} , you've made an installmental payment of {customerowing._InstallmentalAmount} for {customerowing._ProductName}." +
                    $" \n Your Debt remains : {customerowing._PaymentBalance} \n Next Repayment date : {customerowing.NextDueDate}");
            }
            else
            {
                Console.WriteLine("Customers information Not found in your Database");
            }
        }
        internal void DisplayCustomersOwing()
        {

            for (int i = 0; i < customersList.Count; i++)
            {
                InstallmentTracker customers = customersList[i];
                if (customer.RepaymentTimes >= 5)
                {
                    customersList.Remove(customers);
                    continue;
                }
                else if (customersList.Count == 0)
                {
                    Console.WriteLine("No customer is owing you at this moment");
                }
                else
                {
                    Console.WriteLine($"\n Customers {i + 1} Register \n");
                    Console.WriteLine($"Name : {customer._CustomerName}");
                    Console.WriteLine($"Debt Amount : {customer._PaymentBalance}");
                    Console.WriteLine($"Installmentental Amount : {customer._InstallmentalAmount}");
                    Console.WriteLine($"Payment Balance : {customer._PaymentBalance}");
                    Console.WriteLine($"Repayment times : {customer.RepaymentTimes}");
                }

            }

        }
    }
}
