
# CleanCode
Clean Code: busca promover un conjunto de buenas prácticas de codificación. Por eso, he creado este repo donde abordamos tanto los antipatrones como los patrones más utilizados. Todo el contenido está basado en la refactorización de código real.

# Reto para practicar el principio DRY (Don't Repeat Yourself) en C#. 

> Este ejemplo involucrará una aplicación de gestión de empleados en la que se realizan varias operaciones, como calcular el salario y los impuestos de diferentes tipos de empleados.

```c#
    using System;
    using System.Collections.Generic;
    
    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public double TaxRate { get; set; }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Name = "John", Salary = 50000, TaxRate = 0.2 },
                new Employee { Name = "Jane", Salary = 60000, TaxRate = 0.25 }
            };
    
            foreach (var employee in employees)
            {
                double taxAmount = employee.Salary * employee.TaxRate;
                double netSalary = employee.Salary - taxAmount;
    
                Console.WriteLine("Employee: " + employee.Name);
                Console.WriteLine("Gross Salary: " + employee.Salary);
                Console.WriteLine("Tax Amount: " + taxAmount);
                Console.WriteLine("Net Salary: " + netSalary);
                Console.WriteLine();
            }
        }
    }
```
