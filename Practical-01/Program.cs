using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine(" Fasile Technologies Pvt. Ltd.");
        Console.WriteLine(" Employee Bonus Management System");
        Console.WriteLine("========================================");
        Console.WriteLine("Name : Anish Thakur");
        Console.WriteLine("Enrollment No : 92400103303");
        Console.WriteLine();

        Console.WriteLine("Select Employee Category");
        Console.WriteLine("1. Permanent Employee");
        Console.WriteLine("2. Contract Employee");
        Console.Write("Enter Your Choice: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        Employee emp = null;
        IBonus bonus = null;

        if (choice == 1)
        {
            emp = new PermanentEmployee();
            bonus = (IBonus)emp;
        }
        else if (choice == 2)
        {
            emp = new ContractEmployee();
            bonus = (IBonus)emp;
        }
        else
        {
            Console.WriteLine("Invalid Choice!");
            return;
        }

        emp.GetDetails();
        emp.ShowDetails();
        bonus.CalculateBonus();
    }

    interface IBonus
    {
        void CalculateBonus();
    }

    class Employee
    {
        public int employeeId;
        public string employeeName;
        public double basicSalary;

        public Employee()
        {
            Console.WriteLine("\nEnter Employee Details");
        }

        public void GetDetails()
        {
            Console.Write("Employee ID : ");
            employeeId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Employee Name : ");
            employeeName = Console.ReadLine();

            Console.Write("Basic Salary : ");
            basicSalary = Convert.ToDouble(Console.ReadLine());
        }

        public void ShowDetails()
        {
            Console.WriteLine("\n------ Employee Information ------");
            Console.WriteLine("Employee ID : " + employeeId);
            Console.WriteLine("Employee Name : " + employeeName);
            Console.WriteLine("Basic Salary : " + basicSalary);
        }
    }

    class PermanentEmployee : Employee, IBonus
    {
        public void CalculateBonus()
        {
            double performanceBonus = basicSalary * 0.25;
            double festivalBonus = basicSalary * 0.15;
            double travelAllowance = basicSalary * 0.10;
            double tax = basicSalary * 0.05;

            double finalSalary = basicSalary + performanceBonus + festivalBonus + travelAllowance - tax;

            Console.WriteLine("\nEmployee Type : Permanent");
            Console.WriteLine("Performance Bonus : " + performanceBonus);
            Console.WriteLine("Festival Bonus : " + festivalBonus);
            Console.WriteLine("Travel Allowance : " + travelAllowance);
            Console.WriteLine("Tax Deduction : " + tax);
            Console.WriteLine("Final Salary : " + finalSalary);
        }
    }

    class ContractEmployee : Employee, IBonus
    {
        public void CalculateBonus()
        {
            double incentive = basicSalary * 0.10;
            double finalSalary = basicSalary + incentive;

            Console.WriteLine("\nEmployee Type : Contract");
            Console.WriteLine("Incentive : " + incentive);
            Console.WriteLine("Final Salary : " + finalSalary);
        }
    }
}
