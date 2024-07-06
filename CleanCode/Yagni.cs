public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }

    public decimal CalculateMonthlySalary()
    {
        return Salary / 12;
    }
    public decimal CalculateDailySalary()
    {
        return Salary / 365;
    }

    public decimal CalculateWeeklySalary()
    {
        return Salary / 52;
    }

    public decimal CalculateAnnualSalary()
    {
        return Salary;
    }
}
